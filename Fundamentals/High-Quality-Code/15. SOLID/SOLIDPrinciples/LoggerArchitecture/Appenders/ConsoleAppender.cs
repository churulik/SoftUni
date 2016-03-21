namespace LoggerArchitecture.Appenders
{
    using System;
    using Enums;
    using Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void AppendMessage(ReportLevel reportLevel, string message)
        {
            Console.WriteLine(this.Layout.MessageFormat(DateTime.Now, reportLevel, message));
        }
    }
}