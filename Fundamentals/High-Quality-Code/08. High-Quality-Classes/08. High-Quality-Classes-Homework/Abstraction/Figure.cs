namespace Abstraction
{
    public abstract class Figure
    {
        protected Figure(double radius)
        {
            this.Radius = radius;
        }

        protected Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        protected virtual double Width { get; set; }
        protected virtual double Height { get; set; }
        protected virtual double Radius { get; set; }

        public abstract double CalcPerimeter();
        public abstract double CalcSurface();
    }
}
