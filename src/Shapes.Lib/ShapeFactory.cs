using Shapes.Lib.Shapes;

namespace Shapes.Lib;

/// <summary>
/// Shape factory.
/// </summary>
public static class ShapeFactory
{
    /// <summary>
    /// Shape factory.
    /// </summary>
    /// <param name="shapeType"> Shape type. </param>
    /// <param name="parameters"> Shape parameters. </param>
    /// <returns> Shape instance. </returns>
    /// <exception cref="ArgumentOutOfRangeException"> Incorrect parameters were passed. </exception>
    public static IShape CreateShape(ShapeEnum shapeType, params double[] parameters)
    {
        try
        {
            return shapeType switch
            {
                ShapeEnum.Circle => new Circle(parameters[0]),
                ShapeEnum.Triangle => new Triangle(parameters[0], parameters[1], parameters[2]),
                _ => throw new ArgumentOutOfRangeException(nameof(shapeType), shapeType, "It is not possible to create a shape with this type.")
            };
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException(nameof(parameters), parameters, "Number of passed parameters is insufficient to create the shape.");
        }
    }

    /// <summary>
    /// Shape factory.
    /// </summary>
    /// <param name="shapeName"> Shape name. </param>
    /// <param name="parameters"> Shape parameters. </param>
    /// <returns> Shape instance. </returns>
    /// <exception cref="ArgumentOutOfRangeException"> Incorrect parameters were passed. </exception>
    public static IShape CreateShape(string shapeName, params double[] parameters)
    {
        try
        {
            return shapeName.Trim().ToLower() switch
            {
                "circle" => new Circle(parameters[0]),
                "triangle" => new Triangle(parameters[0], parameters[1], parameters[2]),
                _ => throw new ArgumentOutOfRangeException(nameof(shapeName), shapeName, "It is not possible to create a shape with this name.")
            };
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException(nameof(parameters), parameters, "Number of passed parameters is insufficient to create the shape.");
        }
    }

}