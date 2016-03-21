using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.StringDisperser
{
    class StringDisperserApplication
    {
        static void Main()
        {
            var namesA = new StringDisperser("gosho", "pesho", "tanio");
            var namesB = new StringDisperser("gosho", "pesho", "tanio");
            var cars = new StringDisperser("porshe", "volga", "ferrary");
            var vegetables = new StringDisperser("carrot", "tommato", "cucumber");

            Console.WriteLine("namesA == namesB: {0}", namesA == namesB); //True
            Console.WriteLine("namesA != cars: {0}", namesA != cars); //True
            Console.WriteLine("cars == vegetables: {0}", cars.Equals(vegetables));//False

            var cloneNamesA = namesA.Clone();

            Console.WriteLine("cloneNamesA == namesA: {0}", cloneNamesA.Equals(namesA));

            var listOfStrings = new List<StringDisperser>() { namesA, namesB, cars, vegetables };

            listOfStrings.Sort();

            foreach (var output in listOfStrings)
            {
                Console.WriteLine(output);
            }
        }
    }
}
