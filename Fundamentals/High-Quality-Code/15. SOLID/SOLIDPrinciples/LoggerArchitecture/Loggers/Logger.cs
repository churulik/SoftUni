namespace LoggerArchitecture.Loggers
{
    using Enums;
    using Interfaces;

    public class Logger : ILogger
    {
        public Logger(params IAppender[] appender)
        {
            this.Appender = appender;
        }

        public IAppender[] Appender { get; }

        public void Info(string message)
        {
            this.ExecuteLog(ReportLevel.Info, message);
        }

        public void Warnning(string message)
        {
            this.ExecuteLog(ReportLevel.Warnning, message);
        }

        public void Error(string message)
        {
            this.ExecuteLog(ReportLevel.Error, message);
        }

        public void Critical(string message)
        {
            this.ExecuteLog(ReportLevel.Critical, message);
        }

        public void Fatal(string message)
        {
            this.ExecuteLog(ReportLevel.Fatal, message);
        }

        private void ExecuteLog(ReportLevel reportLevel, string message)
        {
            foreach (var appender in this.Appender)
            {
                if (appender.CheckReportLevel(reportLevel))
                {
                    appender.AppendMessage(reportLevel, message);
                }
            }
        }
    }
}