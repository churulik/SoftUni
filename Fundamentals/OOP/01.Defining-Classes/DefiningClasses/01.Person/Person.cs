using System;
using System.Data;

namespace _01.Person
{
    public class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age) : this(name, age, null)
        {

        }

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }


        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Enter a valid name.");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("The age has to be between 0 and 100 years.");
                }
                this.age = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (value != null && !value.Contains("@"))
                {
                    throw new InvalidExpressionException("Invalid e-mail.");
                }
                this.email = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}, Email: {this.Email ?? "N/A"}";
        }
    }
}