using MathArea;

namespace MathAreaTest.Entities
{
    public class CustomShape : IAreable
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public CustomShape(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public double GetArea()
        {
            return Height * Width;
        }
    }
}
