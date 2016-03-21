using System;

class PointInCircle
{
    static void Main()
    {
        Console.Write("Enter the x point: ");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the y point: ");
        double y = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(x * x + y * y <= 2 * 2);
     }
}
