using System;

namespace _04.SoftUniLS.TrainersTypes
{
    public class SeniorTrainer : Trainer
    {
        public void DeleteCourse(string courseName)
        {
            Console.WriteLine(courseName + " has been deleted.");
        }

        public SeniorTrainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }
    }
}