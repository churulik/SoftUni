using System;
using System.Linq;
using _02.Animals.Enums;

namespace _02.Animals
{
    class Zoo
    {
        static void Main()
        {
            var cat = new Cat("Siamka", 2.5, Gender.Female);
            var dog = new Dog("Labrador", 2, Gender.Male);
            var frog = new Frog("Jabcho", 3, Gender.Male);
            var kitten = new Kitten("Kiti", 0.3);
            var tomcat = new Tomcat("Tomi", 0.5);
            
            Animal[] animals = {cat, dog, frog, kitten, tomcat};

            var avgAge = animals.Select(a => a.Age).Average();
            Console.WriteLine("The average age of the animals is " + avgAge);
            Console.WriteLine();
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name + " kaji " + animal.ProduceSound());
                Console.WriteLine($"{animal.Name} kaza {animal.ProduceSound()}");
                Console.WriteLine();
            }
        }
    }
}
