namespace LoggerArchitecture.Interfaces
{
    using Enums;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        bool CheckReportLevel(ReportLevel reportLevel);

        void AppendMessage(ReportLevel reportLevel, string message);
    }
}