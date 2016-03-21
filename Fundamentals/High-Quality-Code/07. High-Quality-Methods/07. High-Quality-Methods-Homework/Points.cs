using System;

namespace Methods
{
    public class Points
    {
        public static double CalcDistanceBetweenTwoPoints(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static bool AreHorizontal(double y1, double y2)
        {
            bool areHorizontal = (y1 == y2);
            return areHorizontal;
        }

        public static bool AreVertical(double x1, double x2)
        {
            bool areVertical = (x1 == x2);
            return areVertical;
        }
    }
}