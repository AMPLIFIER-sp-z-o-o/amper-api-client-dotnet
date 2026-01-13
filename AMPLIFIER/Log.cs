using System;

namespace Amplifier
{
    public class LogSeverity
    {
        public const string Info = "info";
        public const string Warning = "warning";
        public const string Debug = "debug";
        public const string Error = "error";
    }

    public class LogEntry
    {
        public string level;
        public string message;
    }

    public class BackendLog
    {
        public string logSeverity;
        public string message;
        public Exception? exception = null;

        public BackendLog(string logSeverity, string message, Exception? exception = null)
        {
            this.logSeverity = logSeverity;
            this.message = message;
            this.exception = exception;
        }
    }

    public class BackendLogEntryEventArgs<T> : EventArgs
    {
        public BackendLog EventData { get; private set; }

        public BackendLogEntryEventArgs(BackendLog EventData)
        {
            this.EventData = EventData;
        }
    }
}