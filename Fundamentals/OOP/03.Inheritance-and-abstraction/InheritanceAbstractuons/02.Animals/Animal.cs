using System;
using _02.Animals.Enums;
using _02.Animals.Interfaces;

namespace _02.Animals
{
    public abstract class Animal : ISoundProducible
    {
        private string name;
        private double age;

        protected Animal(string name, double age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
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

        public double Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Enter valid age.");
                }
                this.age = value;
            }
        }
        public Gender Gender { get; set; }

        public abstract string ProduceSound();
    }
}