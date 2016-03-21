using System;
using System.Text;

namespace _01.StringExtensions
{
    class Application
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var input = StringExtensions.ToByteArray(" ");
            foreach (var b in input)
            {
                Console.WriteLine(b);
            }
        }
    }
}
