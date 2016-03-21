using System;

class GravitationOnMoon
{
    static void Main()
    {
        Console.Write("Enter the weight of a person: ");
        double weight = Convert.ToDouble(Console.ReadLine());
        double weightOnMoon = weight * 0.17;

        Console.WriteLine("The weight of a person on the Moon will be: {0}", weightOnMoon);        
    }
}

