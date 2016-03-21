namespace LoggerApplication
{
    using LoggerArchitecture.Appenders;
    using LoggerArchitecture.Enums;
    using LoggerArchitecture.Interfaces;
    using LoggerArchitecture.Layouts;
    using LoggerArchitecture.Loggers;

    internal class LoggerMain
    {
        private static void Main()
        {
            ExampleOne();
            ExampleTwo();
            ExampleThree();
            ExampleFour();
        }

        private static void ExampleOne()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender =
                 new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.Error("Error parsing JSON.");
            logger.Info($"User {"Pesho"} successfully registered.");
        }

        private static void ExampleTwo()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            var fileAppender = new FileAppender(simpleLayout);
            fileAppender.File = "../../log.txt";
            var logger = new Logger(consoleAppender, fileAppender);

            logger.Error("Error parsing JSON.");
            logger.Info($"User {"Pesho"} successfully registered.");
            logger.Warnning("Warning - missing files.");
        }

        private static void ExampleThree()
        {
            var xmlLayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(xmlLayout);
            var logger = new Logger(consoleAppender);

            logger.Fatal("mscorlib.dll does not respond");
            logger.Critical("No connection string found in App.config");
        }

        private static void ExampleFour()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = ReportLevel.Error;

            var logger = new Logger(consoleAppender);

            logger.Info("Everything seems fine");
            logger.Warnning("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}