using System;

namespace _01.HumanStudentWorker
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException
                        ("The faculty number lenght has to be between 5 and 10 symbols.");
                }
                this.facultyNumber = value;
            }
        }

        
    }
}