using System;
using System.Collections.Generic;

namespace _01.LinqEnxtension
{
    class Application
    {
        static void Main()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var filter = list.WhereNot(n => n % 2 == 0);
            Console.WriteLine(string.Join(", ", filter));

            var students = new List<Student>
            {
                new Student("Pesho", 3),
                new Student("Gosho", 2),
                new Student("Maria", 6),
                new Student("Ivan", 5),
                new Student("Ivan", 4)
            };
            var max = students.Max(s => s.Grade);
            Console.WriteLine(max);
        }
    }
}
