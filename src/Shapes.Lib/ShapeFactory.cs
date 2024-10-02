using Shapes.Lib.Shapes;

namespace Shapes.Lib;

/// <summary>
/// Shape factory.
/// </summary>
public static class ShapeFactory
{
    /// <summary>
    /// Create shape using type.
    /// </summary>
    /// <param name="shapeType"> Shape type. </param>
    /// <param name="parameters"> Shape parameters. </param>
    /// <returns> Shape instance. </returns>
    /// <exception cref="ArgumentOutOfRangeException"> Incorrect parameters were passed. </exception>
    public static IShape CreateShape(ShapeEnum shapeType, params double[] parameters)
    {
        return shapeType switch
        {
            ShapeEnum.Circle => new Circle(parameters),
            ShapeEnum.Triangle => new Triangle(parameters),
            _ => throw new ArgumentOutOfRangeException(nameof(shapeType), shapeType, "It is not possible to create a shape with this type.")
        };
    }

    /// <summary>
    /// Create shape using name.
    /// </summary>
    /// <param name="shapeName"> Shape name. </param>
    /// <param name="parameters"> Shape parameters. </param>
    /// <returns> Shape instance. </returns>
    /// <exception cref="ArgumentOutOfRangeException"> Incorrect parameters were passed. </exception>
    public static IShape CreateShape(string shapeName, params double[] parameters)
    {
        return shapeName.Trim().ToLower() switch
        {
            "circle" => new Circle(parameters),
            "triangle" => new Triangle(parameters),
            _ => throw new ArgumentOutOfRangeException(nameof(shapeName), shapeName, "It is not possible to create a shape with this name.")
        };
    }

    /// <summary>
    /// Create shape using variable type.
    /// </summary>
    /// <typeparam name="T"> Shape. </typeparam>
    /// <param name="parameters"> Shape parameters. </param>
    /// <returns> Shape instance. </returns>
    /// <exception cref="ArgumentException"> Incorrect parameters were passed. </exception>
    /// <exception cref="MissingMethodException"> No proper constructor. </exception>
    public static T CreateShape<T>(params double[] parameters) where T : IShape
    {
        object? instance;
        try
        {
            instance = Activator.CreateInstance(typeof(T), [parameters]);
        }
        catch (MissingMethodException)
        {
            throw new MissingMethodException("There is no proper constructor to create an instance.");
        }

        return instance == null
            ? throw new ArgumentException($"Failed to create an instance of \"{nameof(T)}\" type.")
            : (T)instance;
    }
}