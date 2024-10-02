namespace Shapes.Lib.Shapes;

/// <summary>
/// Circle shape.
/// </summary>
public class Circle : IShape
{
    private double _radius;

    /// <summary>
    /// Radius.
    /// </summary>
    public double Radius
    {
        get => _radius; 
        set => _radius = GetValidatedRadius(value);
    }

    /// <summary>
    /// Circle constructor.
    /// </summary>
    /// <param name="radius"> Circle radius. </param>
    public Circle(double radius)
    {
        Radius = radius;
    }

    /// <inheritdoc/>
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    /// <summary>
    /// Validates passed radius.
    /// </summary>
    /// <param name="radius"> Radius. </param>
    /// <returns> Validated radius. </returns>
    /// <exception cref="ArgumentException"> Incorrect radius was passed. </exception>
    private double GetValidatedRadius(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be positive");

        return radius;
    }
}