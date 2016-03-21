using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.HumanStudentWorker
{
    class Society
    {
        static void Main()
        {
            var student1 = new Student("Ivan", "Ivanov", "123asc343");
            var student2 = new Student("Vasil", "Petrov", "3424ascd");
            var student3 = new Student("Bogomil", "Genchev", "123sadfe");
            var student4 = new Student("Stanislav", "Marinov", "55daasd");
            var student5 = new Student("Ivan", "Smirnov", "dcg6756");
            var student6 = new Student("Ivan", "Todorov", "dxcasdw");
            var student7 = new Student("Peter", "Bojanov", "34dfthy4");
            var student8 = new Student("Ivan", "Gochev", "dawqw3234");
            var student9 = new Student("Ivan", "Hristov", "cas312");
            var student10 = new Student("Hristo", "Metodiev", "ze234521");

            var listStudents = new List<Student>
            {
                student1,
                student2,
                student3,
                student4,
                student5,
                student6,
                student7,
                student8,
                student9,
                student10
            };

            var orderStudents = listStudents.OrderBy(s => s.FacultyNumber);

            Console.WriteLine("Students:");
            foreach (var student in orderStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} - {student.FacultyNumber}");
            }
            Console.WriteLine();

            var worker1 = new Worker("Ivo", "Gerasimov", 1000, 40);
            var worker2 = new Worker("Petar", "Gerasimov", 3000, 40);
            var worker3 = new Worker("Todor", "Shopov", 1200, 40);
            var worker4 = new Worker("Hristo", "Velichkov", 3200, 40);
            var worker5 = new Worker("Ilia", "Vasilev", 12000, 40);
            var worker6 = new Worker("Maria", "Gerasimova", 10100, 40);
            var worker7 = new Worker("Gergana", "Gerasimova", 30002, 40);
            var worker8 = new Worker("Petia", "Velinova", 5000, 40);
            var worker9 = new Worker("Dobrinka", "Yofcheva", 5999, 40);
            var worker10 = new Worker("Nikolai", "Borisov", 4577, 40);

            var listWorkers = new List<Worker>
            {
                worker1,
                worker2,
                worker3,
                worker4,
                worker5,
                worker6,
                worker7,
                worker8,
                worker9,
                worker10
            };

            var orderWorkers = listWorkers.OrderByDescending(w => w.MoneyPerHour());

            Console.WriteLine("Workers:");
            foreach (var worker in orderWorkers)
            {
                Console.WriteLine($"{worker.FirstName} {worker.LastName} - {worker.MoneyPerHour()} lv/h");
            }

            Console.WriteLine();

            var concatenateLists = orderStudents
                .Cast<Human>()
                .Concat(orderWorkers)
                .OrderBy(h => h.FirstName)
                .ThenBy(h => h.LastName);

            Console.WriteLine("All:");
            foreach (var person in concatenateLists)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
            

        }
    }
}
