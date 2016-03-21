namespace LoggerArchitecture.Interfaces
{
    using System;
    using Enums;

    public interface ILayout
    {
        string MessageFormat(DateTime dateTime, ReportLevel reportLevel, string message);
    }
}