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
        set => _radius = GetValidatedRadius([value]);
    }

    /// <summary>
    /// Circle constructor.
    /// </summary>
    /// <param name="radius"> Circle radius. </param>
    public Circle(double radius)
    {
        Radius = GetValidatedRadius([radius]);
    }

    /// <summary>
    /// Circle constructor.
    /// </summary>
    /// <param name="parameters"> Circle parameters </param>
    public Circle(double[] parameters)
    {
        Radius = GetValidatedRadius(parameters);
    }

    /// <inheritdoc/>
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    /// <summary>
    /// Validates passed parameters.
    /// </summary>
    /// <param name="parameters"> Parameters. </param>
    /// <returns> Validated radius. </returns>
    /// <exception cref="ArgumentException"> Incorrect radius was passed. </exception>
    /// <exception cref="ArgumentOutOfRangeException"> Incorrect amount of parameters passed. </exception>
    private double GetValidatedRadius(double[] parameters)
    {
        double radius;
        try
        {
            radius = parameters[0];
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException(nameof(parameters), parameters, "Number of passed parameters must be at least 1.");
        }

        if (radius <= 0)
            throw new ArgumentException("Radius must be positive");

        return radius;
    }
}