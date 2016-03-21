using System;

namespace Methods
{
    public class Application
    {
        static void Main()
        {
            Console.WriteLine(Shapes.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(Numbers.NumberToItsNumericalName(5));

            Console.WriteLine(Numbers.FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            var formatF = Numbers.FormatNumber(1.3, "f");
            var formatPercentage = Numbers.FormatNumber(0.75, "%");
            var formatR = Numbers.FormatNumber(2.30, "r");
            Console.WriteLine(formatF);
            Console.WriteLine(formatPercentage);
            Console.WriteLine(formatR);

            bool horizontal = Points.AreHorizontal(-1, 2.5);
            bool vertical = Points.AreVertical(3, 3);
            Console.WriteLine(Points.CalcDistanceBetweenTwoPoints(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student
            {
                FirstName = "Peter",
                LastName = "Ivanov",
                OtherInfo = "From Sofia, born at 17.03.1992"
            };

            Student stella = new Student
            {
                FirstName = "Stella",
                LastName = "Markova",
                OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993"
            };

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, StudentMethods.IsOlderThan(peter, stella));
        }
    }
}