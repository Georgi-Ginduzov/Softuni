namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; private set; }
        public double Width { get; private set; }

        public override double CalculateArea()
                => Height * Width;
        public override double CalculatePerimeter()
                => 2 * (Height + Width);
        public override string Draw() => $"Drawing {this.GetType().Name}";

    }
}
