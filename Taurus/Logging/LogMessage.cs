using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Logging
{
    public struct LogMessage
    {
        public LogSeverity Severity { get; private set; }

        public string Source { get; private set; }

        public string Message { get; private set; }

        public Exception? Exception { get; private set; }

        public LogMessage(LogSeverity severity, string source, string message, Exception? ex = null)
        {
            Severity = severity;
            Source = source;
            Message = message;
            Exception = ex;
        }
    }
}
