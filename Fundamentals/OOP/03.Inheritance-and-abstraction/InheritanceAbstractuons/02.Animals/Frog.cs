using System;
using _02.Animals.Enums;

namespace _02.Animals
{
    public class Frog : Animal
    {
        public Frog(string name, double age, Gender gender) : base(name, age, gender)
        {
            
        }

        public override string ProduceSound()
        {
            return "kvak-kvak";
        }
    }
}