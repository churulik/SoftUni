namespace LoggerArchitecture.Layouts
{
    using System;
    using Enums;

    public class XmlLayout : Layout
    {
        public override string MessageFormat(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            var formatedMessage = $"<log>{Environment.NewLine}" +
                                  $"    <date>{dateTime}</date>{Environment.NewLine}" +
                                  $"    <level>{reportLevel}</level>{Environment.NewLine}" +
                                  $"    <message>{message}</message>{Environment.NewLine}" +
                                  "</log>";
            return formatedMessage;
        }
    }
}