using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Lib.Shapes;
using Shapes.Lib.Tests.Utility;

namespace Shapes.Lib.Tests;

[TestClass]
public class FactoryTests : BaseTest
{
    [TestMethod]
    public void TestShapeFactoryForCircle()
    {
        var shape = ShapeFactory.CreateShape(ShapeEnum.Circle, 3);
        var area = shape.CalculateArea();

        Assert.AreEqual(Math.PI * 9, area, Delta);
    }

    [TestMethod]
    public void TestShapeFactoryForTriangleUsingType()
    {
        var shape = ShapeFactory.CreateShape(ShapeEnum.Triangle, 3, 4, 5);
        var area = shape.CalculateArea();

        Assert.AreEqual(6, area, Delta);
    }

    [TestMethod]
    public void TestShapeFactoryForTriangleUsingName()
    {
        var shape = ShapeFactory.CreateShape("Triangle", 3, 4, 5);
        var area = shape.CalculateArea();

        Assert.AreEqual(6, area, Delta);
    }

    [TestMethod]
    public void TestShapeFactoryForCircleUsingGeneric()
    {
        var shape = ShapeFactory.CreateShape<Circle>(3);
        var area = shape.CalculateArea();

        Assert.AreEqual(Math.PI * 9, area, Delta);
    }

    [TestMethod]
    public void TestShapeFactoryForExtensionShape()
    {
        ShapeFactory.RegisterShapeName<Square>();

        var shape = ShapeFactory.CreateShape<Square>(3);
        var area = shape.CalculateArea();

        Assert.AreEqual(9, area, Delta);
    }

    [TestMethod]
    public void TestShapeFactoryRegisterShapeName()
    {
        ShapeFactory.RegisterShapeName<Square>("new shape");

        var shape = ShapeFactory.CreateShape("new shape", 3);
        var area = shape.CalculateArea();

        Assert.AreEqual(9, area, Delta);
    }

    [TestMethod]
    public void TestShapeFactoryRegisterShapeEnum()
    {
        ShapeFactory.RegisterShapeName<Square>(NewShapeEnum.Square);

        var shape = ShapeFactory.CreateShape(NewShapeEnum.Square, 3);
        var area = shape.CalculateArea();

        Assert.AreEqual(9, area, Delta);
    }

    [TestMethod]
    [ExpectedException(typeof(MissingMethodException))]
    public void TestShapeFactoryInvalidParameters()
    {
        ShapeFactory.CreateShape(ShapeEnum.Triangle, 3, 2);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestShapeFactoryInvalidName()
    {
        ShapeFactory.CreateShape("Rectangle", 2, 4, 2, 4);
    }

    [TestMethod]
    [ExpectedException(typeof(MissingMethodException))]
    public void TestShapeFactoryInvalidGeneric()
    {
        ShapeFactory.CreateShape<IShape>(2);
    }
}