namespace _01.Point3D
{
    public class Point3D
    {
        private static readonly Point3D StartPoint = new Point3D(0, 0, 0);
        
        public Point3D(double xCoordinate, double yCoordinate, double zCoordinate)
        {
            this.Xcoordinate = xCoordinate;
            this.Ycoordinate = yCoordinate;
            this.Zcoordinate = zCoordinate;
        }

        public double Xcoordinate { get; set; }
        public double Ycoordinate { get; set; }
        public double Zcoordinate { get; set; }

        public static Point3D StartingPoint { get { return StartPoint; } }
        
        public override string ToString()
        {
            return $"{{{this.Xcoordinate}°, {this.Ycoordinate}°, {this.Zcoordinate}°}}";
        }

        
    }
}