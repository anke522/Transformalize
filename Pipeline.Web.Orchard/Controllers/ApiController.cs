﻿#region license
// Transformalize
// Copyright 2013 Dale Newman
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Localization;
using Orchard.Logging;
using Pipeline.Contracts;
using Pipeline.Web.Orchard.Services;
using Pipeline.Web.Orchard.Models;
using Process = Pipeline.Configuration.Process;

namespace Pipeline.Web.Orchard.Controllers {

    public class ApiController : Controller {

        readonly IOrchardServices _orchardServices;
        readonly IIpRangeService _ipRangeService;

        public Localizer T { get; set; }
        public ILogger Logger { get; set; }

        public ApiController(
            IOrchardServices orchardServices,
            IIpRangeService ipRangeService
        ) {
            _orchardServices = orchardServices;
            _ipRangeService = ipRangeService;
            T = NullLocalizer.Instance;
            Logger = NullLogger.Instance;
        }


        [ActionName("Api/Run")]
        public ContentResult Run(int id) {

            var timer = new Stopwatch();
            timer.Start();
            var format = Request.QueryString["format"] == "json" ? "json" : "xml";

            Response.AddHeader("Access-Control-Allow-Origin", "*");
            var part = _orchardServices.ContentManager.Get(id).As<PipelineConfigurationPart>();

            if (part == null) {
                return Get404("Run", _orchardServices, format);
            }

            if (_orchardServices.Authorizer.Authorize(global::Orchard.Core.Contents.Permissions.ViewContent, part)) {

                var process = format == "json" ? _orchardServices.WorkContext.Resolve<JsonProcess>() : _orchardServices.WorkContext.Resolve<XmlProcess>() as Process;
                var parameters = Common.GetParameters(Request);
                process.Load(part.Configuration, parameters);

                if (process.Errors().Any()) {
                    return Get503("Run", process, format, timer.ElapsedMilliseconds);
                }

                Common.PageHelper(process, Request);

                if (process.Entities.Any(e => !e.Fields.Any(f => f.Input))) {
                    var schemaHelper = _orchardServices.WorkContext.Resolve<ISchemaHelper>();
                    if (schemaHelper.Help(process)) {
                        if (process.Errors().Any()) {
                            return Get503("Run", process, format, timer.ElapsedMilliseconds);
                        }
                    }
                }

                var runner = _orchardServices.WorkContext.Resolve<IRunTimeExecute>();
                try {
                    runner.Execute(process);
                    process.Status = 200;
                    process.Message = "Ok";
                    process.Request = "Run";
                    process.Time = timer.ElapsedMilliseconds;
                    SystemFieldHelper(process);
                    ShorthandHelper(process);
                    return new ContentResult { Content = process.Serialize(), ContentType = "text/" + format };
                } catch (Exception ex) {
                    return Get501(Request, _orchardServices, "Run", ex.Message, timer.ElapsedMilliseconds);
                }

            }

            return Get401(format, _orchardServices, "Run");

        }

        [ActionName("Api/Cfg")]
        public ContentResult Configuration(int id) {
            Response.AddHeader("Access-Control-Allow-Origin", "*");
            var part = _orchardServices.ContentManager.Get(id).As<PipelineConfigurationPart>();

            if (part == null) {
                return Get404("Cfg", _orchardServices, "xml");
            }

            if (_ipRangeService.InRange(Request.UserHostAddress, part.StartAddress, part.EndAddress) || _orchardServices.Authorizer.Authorize(global::Orchard.Core.Contents.Permissions.ViewContent, part)) {
                return new ContentResult { Content = part.Configuration, ContentType = "text/xml" };
            }

            return Get401("Cfg", _orchardServices, "xml");
        }

        [ActionName("Api/Check")]
        public ContentResult Validate(int id) {

            const string action = "Check";
            var timer = new Stopwatch();
            timer.Start();

            Response.AddHeader("Access-Control-Allow-Origin", "*");
            var part = _orchardServices.ContentManager.Get(id).As<PipelineConfigurationPart>();
            var format = Request.QueryString["format"] == "json" ? "json" : "xml";

            if (part == null) {
                timer.Stop();
                return Get404(action, _orchardServices, format, timer.ElapsedMilliseconds);
            }

            if (_orchardServices.Authorizer.Authorize(global::Orchard.Core.Contents.Permissions.ViewContent, part)) {

                var process = format == "json" ? _orchardServices.WorkContext.Resolve<JsonProcess>() : _orchardServices.WorkContext.Resolve<XmlProcess>() as Process;
                var parameters = Common.GetParameters(Request);
                process.Load(part.Configuration, parameters);

                if (process.Errors().Any()) {
                    return Get503(action, process, format, timer.ElapsedMilliseconds);
                }

                if (process.Entities.Any(e => !e.Fields.Any(f => f.Input))) {
                    var schemaHelper = _orchardServices.WorkContext.Resolve<ISchemaHelper>();
                    if (schemaHelper.Help(process)) {
                        if (process.Errors().Any()) {
                            return Get503(action, process, format, timer.ElapsedMilliseconds);
                        }
                    }
                }

                SystemFieldHelper(process);
                ShorthandHelper(process);
                process.Request = action;
                process.Status = 200;
                process.Time = timer.ElapsedMilliseconds;  // not including cost of serialize
                process.Message = "Ok";


                return new ContentResult { Content = process.Serialize(), ContentType = "text/" + format };
            }

            return Get401(action, _orchardServices, format);

        }

        private static void SystemFieldHelper(Process process) {
            foreach (var connection in process.Connections) {
                connection.ConnectionString = string.Empty;
                connection.User = string.Empty;
                connection.Password = string.Empty;
            }
            if (!process.Output().IsInternal()) {
                return;
            }
            foreach (var entity in process.Entities) {
                entity.Fields.RemoveAll(f => f.System);
            }
        }

        private static void ShorthandHelper(Process process) {
            foreach (var field in process.GetAllFields().Where(f => !string.IsNullOrEmpty(f.T))) {
                field.T = string.Empty;
            }
        }

        private static ContentResult Get404(string action, IOrchardServices services, string format, long time = 5) {
            var process = format == "json" ? (Process)services.WorkContext.Resolve<JsonProcess>() : services.WorkContext.Resolve<XmlProcess>();
            process.Request = action;
            process.Status = 404;
            process.Message = "Configuration not found.";
            process.Time = time;
            return new ContentResult { Content = process.Serialize(), ContentType = "text/" + format };
        }

        private static ContentResult Get401(string action, IOrchardServices services, string format, long time = 5) {
            var process = format == "json" ? (Process)services.WorkContext.Resolve<JsonProcess>() : services.WorkContext.Resolve<XmlProcess>();
            process.Request = action;
            process.Status = 401;
            process.Message = "Unauthorized";
            process.Time = time;
            return new ContentResult { Content = process.Serialize(), ContentType = "text/" + format };
        }

        private static ContentResult Get503(string action, Process process, string format, long time) {
            process.Request = action;
            process.Status = 503;
            process.Message = string.Join("\n", process.Errors());
            process.Time = time;
            return new ContentResult { Content = process.Serialize(), ContentType = "text/" + format };
        }

        private static ContentResult Get501(HttpRequestBase request, IOrchardServices services, string action, string message, long time = 5) {
            var format = request.QueryString["format"] == "json" ? "json" : "xml";
            var process = format == "json" ? (Process)services.WorkContext.Resolve<JsonProcess>() : services.WorkContext.Resolve<XmlProcess>();
            process.Request = action;
            process.Status = 501;
            process.Message = message;
            process.Time = time;
            return new ContentResult { Content = process.Serialize(), ContentType = "text/" + format };
        }
    }
}