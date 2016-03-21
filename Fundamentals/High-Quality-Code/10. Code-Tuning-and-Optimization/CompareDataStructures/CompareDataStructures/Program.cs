using System.Diagnostics;

namespace CompareDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {

            var phoneBookList = new List<Person>()
            {
                new Person("Ivan Kolev", "0884857634"),
                new Person("Petko Karamatev", "0889467124")
            };

            var phoneBookDictionary = new Dictionary<string, string>
            {
                {"Ivan Kolev", "0884857634"},
                {"Petko Karamatev", "0889467124"}
            };
            var sw = new Stopwatch();
            sw.Start();
            var bai = new Search<Person>(phoneBookList, "Ivan Kolev");
            foreach (var b in bai)
            {
                Console.WriteLine(b.Name);
            }
            Console.WriteLine(sw.Elapsed);
            sw.Restart();

            for (int i = 0; i < 1000; i++)
            {
                var person = phoneBookDictionary.Keys;
            }
            Console.WriteLine(sw.Elapsed);
            sw.Stop();

        }
    }
}
