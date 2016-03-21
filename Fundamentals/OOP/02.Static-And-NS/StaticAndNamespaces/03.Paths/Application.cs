using System;
using System.Collections.Generic;
using _01.Point3D;

namespace _03.Paths
{
    class Application
    {
        static void Main()
        {
            var paths = new Path3D(
                new Point3D(3, 3, 3),
                new Point3D(5, 6, 8),
                new Point3D(-3, 4, 21)
                );

            Storage.Save(paths);
            Storage.Load();
        }
    }
}
