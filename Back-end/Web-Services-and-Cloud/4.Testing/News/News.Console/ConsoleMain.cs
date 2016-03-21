using System.Linq;
using News.Data;

namespace News.Console
{
    using System;

    class ConsoleMain
    {
        static void Main()
        {
            var context = new NewsContext();

            Console.WriteLine(context.News.Count());
        }
    }
}
