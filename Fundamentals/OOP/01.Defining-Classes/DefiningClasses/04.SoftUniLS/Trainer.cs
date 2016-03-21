using System;

namespace _04.SoftUniLS
{
    public class Trainer : Person
    {
        public void CreateCourse(string courseName)
        {
            Console.WriteLine(courseName + " has been created.");
        }

        public Trainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }
    }
}