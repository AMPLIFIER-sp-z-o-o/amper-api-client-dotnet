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
}