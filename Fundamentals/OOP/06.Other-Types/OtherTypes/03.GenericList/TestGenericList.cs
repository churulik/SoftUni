using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace _03.GenericList
{
    class TestGenericList
    {
        static void Main()
        {
            var list = new GenericList<int>(4);
            list.Add(22);
            list.Add(33);
            list.Add(1);
            list.Add(16);
            list.Add(8);
            list.Add(21);
            list.Add(3);
            list.Print();

            list.Insert(0, 9);
            list.Print();

            var index = list.IndexOf(33);
            Console.WriteLine(index);

            var tr = list.Contains(16);
            Console.WriteLine(tr);

            var fl = list.Contains(102);
            Console.WriteLine(fl);

            var find = list.FindIndex(x => x == 1);
            Console.WriteLine(find);

            list.Remove(33);
            list.Print();
            
            //exception
            //list.Remove(332);
            //list.Print();

            list.RemoveAt(1);
            list.Print();

            var min = list.Min();
            var max = list.Max();

            Console.WriteLine(min);
            Console.WriteLine(max);

            list.Clear();
            list.Print();

            //Problem 4. Generic List Version

            var typeOfList = typeof(GenericList<>);
            var atributes = typeOfList.GetCustomAttributes(false);

            foreach (VersionAttribute attribute in atributes)
            {
                Console.WriteLine("Version " + attribute.Version);
            }
        }
    }
}
