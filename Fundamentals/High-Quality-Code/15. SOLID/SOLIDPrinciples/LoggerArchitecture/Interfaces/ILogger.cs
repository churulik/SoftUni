namespace LoggerArchitecture.Interfaces
{
    public interface ILogger
    {
        IAppender[] Appender { get; }

        void Info(string message);

        void Warnning(string message);

        void Error(string message);

        void Critical(string message);

        void Fatal(string message);
    }
}