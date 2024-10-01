namespace Shapes.Lib.Shapes;

/// <summary>
/// Circle shape.
/// </summary>
public class Circle : IShape
{
    /// <summary>
    /// Radius.
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Circle constructor.
    /// </summary>
    /// <param name="radius"> Circle radius. </param>
    /// <exception cref="ArgumentException"> Incorrect radius was passed. </exception>
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be positive");

        Radius = radius;
    }

    /// <inheritdoc/>
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}