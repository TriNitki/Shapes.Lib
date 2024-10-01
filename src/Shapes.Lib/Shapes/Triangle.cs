namespace Shapes.Lib.Shapes;

/// <summary>
/// Triangle shape.
/// </summary>
public class Triangle : IShape
{
    /// <summary>
    /// First side.
    /// </summary>
    public double SideA { get; }

    /// <summary>
    /// Second side.
    /// </summary>
    public double SideB { get; }

    /// <summary>
    /// Third side.
    /// </summary>
    public double SideC { get; }


    /// <summary>
    /// Triangle constructor.
    /// </summary>
    /// <param name="sides"> Triangle sides. </param>
    public Triangle(params double[] sides)
    {
        ValidateSides(sides);

        SideA = sides[0];
        SideB = sides[1];
        SideC = sides[2];
    }

    /// <inheritdoc/>
    public double CalculateArea()
    {
        var s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    /// <summary>
    /// Checks if the triangle is right.
    /// </summary>
    /// <returns> <see langword="true"/> if the triangle is right and <see langword="false"/> otherwise. </returns>
    public bool IsRightTriangle()
    {
        double[] sides = [SideA, SideB, SideC];
        Array.Sort(sides);
        return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1e-10;
    }

    /// <summary>
    /// Validate passed sides.
    /// </summary>
    /// <param name="sides"> Triangle sides. </param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"> Incorrect sides were passed. </exception>
    /// <exception cref="ArgumentException"> Incorrect sides were passed.  </exception>
    private void ValidateSides(params double[] sides)
    {
        try
        {
            sides = [sides[0], sides[1], sides[2]];
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException(nameof(sides), sides, "Number of passed sides must be at least 3.");
        }

        if (sides[0] <= 0 || sides[1] <= 0 || sides[2] <= 0)
            throw new ArgumentException("Sides must be positive.");

        if (!(sides[0] + sides[1] > sides[2] && sides[0] + sides[2] > sides[1] && sides[1] + sides[2] > sides[0]))
            throw new ArgumentException("Sum of any two sides must be greater than the third side.");
    }
}