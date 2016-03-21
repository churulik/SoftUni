using System;

class Rectangles
{
    static void Main()
    {
        Console.Write("Enter the width: ");
        double width = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the height: ");
        double height = Convert.ToDouble(Console.ReadLine());
        double perimeter = (width + height) * 2;
        double area = width * height;
        Console.WriteLine("The perimeter is: {0}", perimeter);
        Console.WriteLine("The area is: {0}", area );
      }
}

