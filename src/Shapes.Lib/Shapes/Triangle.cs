namespace Shapes.Lib.Shapes;

/// <summary>
/// Triangle shape.
/// </summary>
public class Triangle : IShape
{
    private double[] _sides;

    /// <summary>
    /// Triangle sides.
    /// </summary>
    public double[] Sides
    {
        get => _sides;
        set => _sides = GetValidatedSides(value);
    }

    /// <summary>
    /// Triangle constructor.
    /// </summary>
    /// <param name="sideA"> First side. </param>
    /// <param name="sideB"> Second side. </param>
    /// <param name="sideC"> Third side. </param>
    public Triangle(double sideA, double sideB, double sideC)
    {
        Sides = [sideA, sideB, sideC];
    }

    /// <summary>
    /// Triangle constructor.
    /// </summary>
    /// <param name="sides"> Array of sides. </param>
    public Triangle(double[] sides)
    {
        Sides = sides;
    }

    /// <inheritdoc/>
    public double CalculateArea()
    {
        var s = (_sides[0] + _sides[1] + _sides[2]) / 2;
        return Math.Sqrt(s * (s - _sides[0]) * (s - _sides[1]) * (s - _sides[2]));
    }

    /// <summary>
    /// Checks if the triangle is right.
    /// </summary>
    /// <returns> <see langword="true"/> if the triangle is right and <see langword="false"/> otherwise. </returns>
    public bool IsRightTriangle()
    {
        double[] sides = [_sides[0], _sides[1], _sides[2]];
        Array.Sort(sides);
        return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1e-10;
    }

    /// <summary>
    /// Validates passed sides.
    /// </summary>
    /// <param name="sides"> Triangle sides. </param>
    /// <returns> Validated triangle sides. </returns>
    /// <exception cref="ArgumentOutOfRangeException"> Incorrect amount of sides passed. </exception>
    /// <exception cref="ArgumentException"> Incorrect sides were passed.  </exception>
    private double[] GetValidatedSides(double[] sides)
    {
        try
        {
            sides = [sides[0], sides[1], sides[2]];
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException(nameof(sides), sides, "Number of passed parameters must be at least 3.");
        }

        if (sides[0] <= 0 || sides[1] <= 0 || sides[2] <= 0)
            throw new ArgumentException("Sides must be positive.");

        if (!(sides[0] + sides[1] > sides[2] && sides[0] + sides[2] > sides[1] && sides[1] + sides[2] > sides[0]))
            throw new ArgumentException("Sum of any two sides must be greater than the third side.");

        return sides;
    }
}