using System;

namespace _01.Point3D
{
    class Application
    {
        static void Main()
        {
            var points = new Point3D(12, 13, 344);

            var startingPoint = Point3D.StartingPoint;
//            startingPoint.Xcoordinate = 24;
//            startingPoint.Ycoordinate = 124;
//            startingPoint.Zcoordinate = -24;
            
            Console.WriteLine(points);
            Console.WriteLine(startingPoint);
        }
    }
}
