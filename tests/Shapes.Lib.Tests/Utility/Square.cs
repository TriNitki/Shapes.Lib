using Shapes.Lib.Shapes;

namespace Shapes.Lib.Tests.Utility;

internal class Square : IShape
{
    public double Side { get; set; }

    public Square(double side)
    {
        Side = side;
    }

    public double CalculateArea()
    {
        return Side * Side;
    }

}