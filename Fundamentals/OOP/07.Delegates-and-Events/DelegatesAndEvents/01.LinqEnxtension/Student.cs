using System;

namespace _01.LinqEnxtension
{
    public class Student
    {
        private string name;
        private int grade;

        public Student(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Enter valid name.");
                }
                this.name = value;
            }
        }

        public int Grade
        {
            get { return this.grade; }
            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException("Enter valid grade (between 2 and 6).");
                }
                this.grade = value;
            }
        } 
    }
}