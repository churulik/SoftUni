namespace LoggerArchitecture.Layouts
{
    using System;
    using Enums;
    using Interfaces;

    public abstract class Layout : ILayout
    {
        public abstract string MessageFormat(DateTime dateTime, ReportLevel reportLevel, string message);
    }
}