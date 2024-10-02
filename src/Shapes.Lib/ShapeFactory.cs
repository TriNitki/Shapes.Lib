using Shapes.Lib.Shapes;
using System.Reflection;

namespace Shapes.Lib;

/// <summary>
/// Shape factory.
/// </summary>
public static class ShapeFactory
{
    /// <summary>
    /// Registered shapes.
    /// </summary>
    private static readonly Dictionary<string, Type> ShapeNames = new()
    {
        { "circle", typeof(Circle) },
        { "triangle", typeof(Triangle) }
    };

    /// <summary>
    /// Register shape name in the factory.
    /// </summary>
    /// <typeparam name="T"> Shape type. </typeparam>
    /// <param name="name"> Shape name. </param>
    public static void RegisterShapeName<T>(string name) where T : IShape
    {
        AddShapeName(name, typeof(T));
    }

    /// <summary>
    /// Register shape name in the factory.
    /// </summary>
    /// <typeparam name="T"> Shape type. </typeparam>
    public static void RegisterShapeName<T>() where T : IShape
    {
        AddShapeName(nameof(T), typeof(T));
    }

    /// <summary>
    /// Register shape name in the factory.
    /// </summary>
    /// <typeparam name="T"> Shape type. </typeparam>
    /// <param name="enumValue"> Enum value that represents shape. </param>
    public static void RegisterShapeName<T>(Enum enumValue) where T : IShape
    {
        AddShapeName(enumValue.ToString(), typeof(T));
    }

    /// <summary>
    /// Create shape using enum.
    /// </summary>
    /// <param name="shapeType"> Shape enum. </param>
    /// <param name="parameters"> Shape parameters. </param>
    /// <returns> Shape instance. </returns>
    /// <exception cref="ArgumentException"> Shape is not registered. </exception>
    public static IShape CreateShape(Enum shapeType, params object[] parameters)
    {
        Type shape;
        try
        {
            shape = ShapeNames[shapeType.ToString().Trim().ToLower()];
        }
        catch (KeyNotFoundException)
        {
            throw new ArgumentException("Passed \"shapeType\" is not registered in ShapeFactory.");
        }

        return (IShape) GetInstance(shape, parameters);
    }

    /// <summary>
    /// Create shape using name.
    /// </summary>
    /// <param name="shapeName"> Shape name. </param>
    /// <param name="parameters"> Shape parameters. </param>
    /// <returns> Shape instance. </returns>
    /// <exception cref="ArgumentException"> Incorrect parameters were passed. </exception>
    public static IShape CreateShape(string shapeName, params object[] parameters)
    {
        Type shape;
        try
        {
            shape = ShapeNames[shapeName.Trim().ToLower()];
        }
        catch (KeyNotFoundException)
        {
            throw new ArgumentException("Passed \"shapeName\" is not registered in ShapeFactory.");
        }

        return (IShape) GetInstance(shape, parameters);
    }

    /// <summary>
    /// Create shape using variable type.
    /// </summary>
    /// <typeparam name="T"> Shape. </typeparam>
    /// <param name="parameters"> Shape parameters. </param>
    /// <returns> Shape instance. </returns>
    public static T CreateShape<T>(params object[] parameters) where T : IShape
    {
        return (T) GetInstance(typeof(T), parameters);
    }

    /// <summary>
    /// Get shape instance.
    /// </summary>
    /// <param name="shapeType"> Shape type. </param>
    /// <param name="parameters"> Parameters for shape constructor. </param>
    /// <returns> Shape instance. </returns>
    /// <exception cref="ArgumentException"> Incorrect parameters were passed. </exception>
    /// <exception cref="MissingMethodException"> No proper constructor. </exception>
    private static object GetInstance(Type shapeType, object[] parameters)
    {
        object? instance;

        try
        {
            instance = Activator.CreateInstance(shapeType, parameters);
        }
        catch (TargetInvocationException ex)
        {
            throw ex.InnerException!;
        }
        catch (MissingMethodException)
        {
            throw new MissingMethodException("There is no proper constructor to create an instance.");
        }

        return instance ?? throw new ArgumentException($"Failed to create an instance of \"{nameof(shapeType)}\" type.");
    }

    /// <summary>
    /// Add shape name to registered shapes.
    /// </summary>
    /// <param name="shapeName"> Shape name. </param>
    /// <param name="shapeType"> Shape type. </param>
    /// <exception cref="ArgumentException"> Shape name is already registered. </exception>
    private static void AddShapeName(string shapeName, Type shapeType)
    {
        try
        {
            ShapeNames.Add(shapeName.Trim().ToLower(), shapeType);
        }
        catch (ArgumentException)
        {
            throw new ArgumentException($"A shape with the same name has already been added. Name: {nameof(shapeType)}");
        }
    }
}