using System;
using _01.Point3D;

namespace _02.DistanceCalculator
{
    static class DistanceCalculator
    {
        public static double Calculate(Point3D a, Point3D b)
        {
            var x = a.Xcoordinate - b.Xcoordinate;
            var y = a.Ycoordinate - b.Ycoordinate;
            var z = a.Zcoordinate - b.Zcoordinate;

            var xPow = Math.Pow(x, 2);
            var yPow = Math.Pow(y, 2);
            var zPow = Math.Pow(z, 2);

            var distance = Math.Sqrt(xPow + yPow + zPow);

            return distance;
        }
    }
}