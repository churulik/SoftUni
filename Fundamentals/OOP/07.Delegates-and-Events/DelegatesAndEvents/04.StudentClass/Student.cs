using System;

namespace _04.StudentClass
{
    public class Student
    {
        public event PropertyChangedEventHandler PropertyChange;

        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
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
                this.OnChange("Name", this.name, value);
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Enter valid age.");
                }
                this.OnChange("Age", this.age, value);
                this.age = value;
            }
        }

        private void OnChange(string propName, dynamic oldAge, dynamic newAge)
        {
            if (this.PropertyChange != null)
            {
                this.PropertyChange(this, new PropertyChangedEventArgs(propName, oldAge, newAge));
            }
        }
    }
}