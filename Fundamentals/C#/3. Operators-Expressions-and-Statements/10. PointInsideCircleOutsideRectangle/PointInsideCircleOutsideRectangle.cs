using System;

    class PointInsideCircleOutsideRectangle
    {
        static void Main()
        {
            Console.Write("Enter the x point: ");
            double x = Convert.ToDouble(Console.ReadLine());      
            double circleX = x - 1; // - 1 because the circles cordinates are {1:1}
            Console.Write("Enter the y point: ");
            double y = Convert.ToDouble(Console.ReadLine());
            double circleY = y - 1; // - 1 because the circles cordinates are {1:1}
            bool insideCircle = (circleX * circleX + circleY * circleY <= 1.5 * 1.5);
            bool insideRectangle = (-1 <= x && x <= 5 && -1 <= y && y <= 1);
            bool outsideRectangle = ! insideRectangle;
            bool result = insideCircle && outsideRectangle;
            Console.WriteLine("The points are inside the circle and outside of the recrangle? {0}", result ? "Yes" : "No");
          }
    }
