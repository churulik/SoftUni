namespace LoggerArchitecture.Appenders
{
    using System;
    using Enums;
    using Interfaces;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout) : base(layout)
        {
        }

        public string File { get; set; }

        public override void AppendMessage(ReportLevel reportLevel, string message)
        {
            using (var appendText = System.IO.File.AppendText(this.File))
            {
                appendText.WriteLine("{0}{1}", this.Layout.MessageFormat(DateTime.Now, reportLevel, message), Environment.NewLine.TrimEnd());
            }
        }
    }
}