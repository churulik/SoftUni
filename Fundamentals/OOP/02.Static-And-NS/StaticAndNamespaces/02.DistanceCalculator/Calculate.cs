using System;
using _01.Point3D;

namespace _02.DistanceCalculator
{
    class Calculate
    {
        static void Main()
        {
            var pointA = new Point3D(-7, -4, 3);
            var pointB = new Point3D(17, 6, 2.5);

            var calc = DistanceCalculator.Calculate(pointA, pointB);
            Console.WriteLine(calc);
        }
    }
}
