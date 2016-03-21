using _02.Animals.Enums;

namespace _02.Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, double age) : base(name, age, Gender.Female)
        {
        }
    }
}