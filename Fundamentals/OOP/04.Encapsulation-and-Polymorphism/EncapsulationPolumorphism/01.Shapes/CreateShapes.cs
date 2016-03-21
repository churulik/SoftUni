using System;
using _01.Shapes.Interfaces;
using _01.Shapes.Shapes;

namespace _01.Shapes
{
    class CreateShapes
    {
        static void Main()
        {
            var rhombus = new Rhombus(4, 5, 4);
            var rectangle = new Rectangle(16, 3);
            var circle = new Circle(3);
            IShape[] shapes = { rhombus, rectangle, circle };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }
        }
    }
}
