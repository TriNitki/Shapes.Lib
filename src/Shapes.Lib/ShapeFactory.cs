using Shapes.Lib.Shapes;

namespace Shapes.Lib;

/// <summary>
/// Shape factory.
/// </summary>
public class ShapeFactory
{
    /// <summary>
    /// Shape factory.
    /// </summary>
    /// <param name="shapeType"> Shape type. </param>
    /// <param name="parameters"> Shape parameters. </param>
    /// <returns> Shape instance. </returns>
    /// <exception cref="ArgumentOutOfRangeException">  </exception>
    public static IShape CreateShape(ShapeEnum shapeType, params double[] parameters)
    {
        try
        {
            return shapeType switch
            {
                ShapeEnum.Circle => new Circle(parameters[0]),
                ShapeEnum.Triangle => new Triangle(parameters[0], parameters[1], parameters[2]),
                _ => throw new ArgumentOutOfRangeException(nameof(shapeType), shapeType, "Such a shapeType does not exist.")
            };
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException(nameof(parameters), parameters, "Number of passed parameters is insufficient to create the shape.");
        }
    }
}