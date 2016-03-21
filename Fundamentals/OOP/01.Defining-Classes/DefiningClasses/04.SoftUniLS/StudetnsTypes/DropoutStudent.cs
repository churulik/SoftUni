using System;

namespace _04.SoftUniLS.StudetnsTypes
{
    public class DropoutStudent : Student
    {
        public string DropoutReason { get; set; }

        public static void Replay(DropoutStudent person)
        {
            var output = $"Name: {person.FirstName} {person.LastName}\n" +
                         $"Age {person.Age}\n" +
                         $"Student Number: {person.StudentNumber}\n" +
                         $"Avarege Grade: {person.AvgGrade}\n" +
                         $"Dropout Reason: {person.DropoutReason}";
            Console.WriteLine(output);
        }

        public DropoutStudent(string firstName, string lastName, int age, 
            string stdNum, double avgGrd, string dropuotReason) 
            : base(firstName, lastName, age, stdNum, avgGrd)
        {
            this.DropoutReason = dropuotReason;
        }
    }
}