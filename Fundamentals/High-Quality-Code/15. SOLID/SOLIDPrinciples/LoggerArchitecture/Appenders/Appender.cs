namespace LoggerArchitecture.Appenders
{
    using Enums;
    using Interfaces;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public bool CheckReportLevel(ReportLevel reportLevel)
        {
            if (reportLevel >= this.ReportLevel)
            {
                return true;
            }

            return false;
        }

        public abstract void AppendMessage(ReportLevel reportLevel, string message);
    }
}