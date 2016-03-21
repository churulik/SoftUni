using System;
using System.Runtime.InteropServices;

namespace _01.Person
{
    class Application
    {
        static void Main()
        {
            var personA = new Person("Ivan", 23, "email@mail.com");
            var personB = new Person("Peter", 261);

            Console.WriteLine(personA);
            Console.WriteLine(personB);
        }
    }
}
