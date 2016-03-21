using System;

class PlayWithIntDoubleString
{
    static void Main()
    {
        Console.Write("Please choose a type: 1 --> int, 2 --> double, 3 --> string: ");
        string type = Console.ReadLine();
        switch (type)
        {
            case "1": Console.Write("Please enter an int: ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine(a + 1);
                break;
            case "2": Console.Write("Please enter a double: ");
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine(b + 1);
                break;
            case "3": Console.Write("Please enter a string: ");
                string c = Console.ReadLine();
                Console.WriteLine(c + "*");
                break;
            default: Console.WriteLine("Invalide entry");
                break;
        }
    }
}

