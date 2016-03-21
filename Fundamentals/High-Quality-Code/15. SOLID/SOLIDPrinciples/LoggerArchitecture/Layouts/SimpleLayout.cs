namespace LoggerArchitecture.Layouts
{
    using System;
    using Enums;

    public class SimpleLayout : Layout
    {
        public override string MessageFormat(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            var formatedMessage = $"{dateTime} - {reportLevel} - {message}";
            return formatedMessage;
        }
    }
}