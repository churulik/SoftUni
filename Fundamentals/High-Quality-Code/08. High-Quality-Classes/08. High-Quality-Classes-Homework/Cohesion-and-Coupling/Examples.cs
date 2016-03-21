using System;

namespace CohesionAndCoupling
{
    class Examples
    {
        static void Main()
        {
            Console.WriteLine(File.GetFileExtension("example"));
            Console.WriteLine(File.GetFileExtension("example.pdf"));
            Console.WriteLine(File.GetFileExtension("example.new.pdf"));

            Console.WriteLine(File.GetFileNameWithoutExtension("example"));
            Console.WriteLine(File.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(File.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                DistanceCalculator.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                DistanceCalculator.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Shape shape = new Shape(3, 4, 5);
            
            Console.WriteLine("Volume = {0:f2}", shape.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", shape.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", shape.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", shape.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", shape.CalcDiagonalYZ());
        }
    }
}
