using System.Collections.Generic;
using _01.Point3D;

namespace _03.Paths
{
    public class Path3D
    {
        public Path3D(params Point3D[] points)
        {
            this.Points = new List<Point3D>(points);
        }
        public List<Point3D> Points { get; set; }

        public override string ToString()
        {
            return string.Join(", ", this.Points);
        }
    }
}