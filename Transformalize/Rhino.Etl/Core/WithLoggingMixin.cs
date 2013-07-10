using System;
using System.Collections.Generic;
using System.Globalization;
using Transformalize.Rhino.Etl.Core.Exceptions;
using LogManager = Transformalize.NLog.LogManager;
using Logger = Transformalize.NLog.Logger;

namespace Transformalize.Rhino.Etl.Core {
    /// <summary>
    /// A base class that expose easily logging events
    /// </summary>
    public class WithLoggingMixin {
        private readonly Logger _log;
        readonly List<Exception> _errors = new List<Exception>();

        /// <summary>
        /// Initializes a new instance of the <see cref="WithLoggingMixin"/> class.
        /// </summary>
        protected WithLoggingMixin() {
            _log = LogManager.GetCurrentClassLogger();
        }

        protected void Error(Exception exception, string format, params object[] args) {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            var errorMessage = exception != null ? string.Format("{0}: {1}", message, exception.Message) : message;

            _errors.Add(new RhinoEtlException(errorMessage, exception));
            if (_log.IsErrorEnabled) {
                _log.Error(message, exception);
            }
        }

        protected void Error(string format, params object[] args) {
            if (_log.IsErrorEnabled)
                _log.Error(format, args);
        }

        protected void Error(string message) {
            if (_log.IsErrorEnabled)
                _log.Error(message);
        }

        protected void Warn(string format, params object[] args) {
            if (_log.IsWarnEnabled) {
                _log.Warn(format, args);
            }
        }

        /// <summary>
        /// Logs a debug message
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        protected void Debug(string format, params object[] args) {
            if (_log.IsDebugEnabled) {
                _log.Debug(format, args);
            }
        }


        /// <summary>
        /// Logs a notice message
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        protected void Trace(string format, params object[] args) {
            if (_log.IsTraceEnabled) {
                _log.Trace(format, args);
            }
        }


        /// <summary>
        /// Logs an information message
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        protected void Info(string format, params object[] args) {
            if (_log.IsInfoEnabled) {
                _log.Info(format, args);
            }
        }

        /// <summary>
        /// Gets all the errors
        /// </summary>
        /// <value>The errors.</value>
        public Exception[] Errors {
            get { return _errors.ToArray(); }
        }
    }
}