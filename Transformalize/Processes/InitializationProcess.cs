#region License

// /*
// Transformalize - Replicate, Transform, and Denormalize Your Data...
// Copyright (C) 2013 Dale Newman
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */

#endregion

using System.Linq;
using Transformalize.Extensions;
using Transformalize.Libs.NLog;
using Transformalize.Libs.Rhino.Etl;
using Transformalize.Main;
using Transformalize.Operations;

namespace Transformalize.Processes {
    public class InitializationProcess : EtlProcess {

        public InitializationProcess(Process process)
            : base(ref process) {
            process.OutputConnection.TflWriter.Initialize(process);
            process.OutputConnection.ViewWriter.Drop(process);
        }

        protected override void Initialize() {

            GlobalDiagnosticsContext.Set("entity", Common.LogLength("All"));

            foreach (var entity in Process.Entities) {
                Register(new EntityDrop(Process, entity));
                Register(new EntityCreate(Process, entity));
            }
        }

        protected override void PostProcessing() {
            var errors = GetAllErrors().ToArray();
            if (errors.Any()) {
                foreach (var error in errors) {
                    foreach (var inner in error.FlattenHierarchy()) {
                        Error("Failed execution. {0} {1}", inner.Message, inner.StackTrace);
                    }
                }
                throw new TransformalizeException("Initialization Process failed for {0}. See error log.", Process.Name);
            }

            if (Process.StarEnabled && Process.Entities.Count > 0) {
                Process.OutputConnection.ViewWriter.Create(Process);
            }
            Process.InitializeView();
            base.PostProcessing();
        }
    }
}