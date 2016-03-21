using System;
using _02.Animals.Enums;

namespace _02.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, double age, Gender gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "bauu-bauu";
        }
    }
}