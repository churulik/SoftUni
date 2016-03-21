using System;
using System.Collections.Generic;
using System.Linq;
using _04.SoftUniLS.StudetnsTypes;
using _04.SoftUniLS.TrainersTypes;

namespace _04.SoftUniLS
{
    class SULSTest
    {
        static void Main()
        {
            var people = new List<Person>()
            {
                new Person("Ivan", "Ivanov", 23),
                new Trainer("Petko", "Georgiev", 34),
                new Student("Peter", "Petrov", 33, "Gevrec245", 3.33),
                new JuniorTrainer("Jordan", "Ivonov", 21),
                new SeniorTrainer("Eban", "Gigov", 99),
                new GraduatedStudent("Ivo", "Balabnof", 45, "NiamdaG0Kaja2pati", 4.55),
                new CurrentStudent("Jori", "Kumenov", 34, "ggag24", 4.3, "OOP"),
                new CurrentStudent("Bobi", "Bogov", 86, "vik34e", 5.59, "OOP"),
                new DropoutStudent("Huhu", "Belev", 52, "fff", 2.2, "Surprise!!!")
            };

            var currentStudentList = 
                people.Where(p => p is CurrentStudent).Cast<CurrentStudent>().ToList();

            var sort = currentStudentList.OrderByDescending(s => s.AvgGrade);
                
            foreach (var std in sort)
            {
                Console.WriteLine(std.FirstName + " " + std.AvgGrade + " " + std.CurrentCourse);
                
            }
           
        }
    }
}
