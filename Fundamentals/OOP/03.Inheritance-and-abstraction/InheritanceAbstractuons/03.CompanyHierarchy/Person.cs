using System;
using _03.CompanyHierarchy.Interfaces;

namespace _03.CompanyHierarchy
{
    public abstract class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;

        protected Person(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Enter 'id' bigger than 0.");
                }
                this.id = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Enter a valid first name.");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Enter a valid last name.");
                }
                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return $"Position: {this.GetType().Name}\n" +
                   $"Id: {this.Id}\n" +
                   $"Name: {this.FirstName} {this.LastName}\n";
        }
    }
}