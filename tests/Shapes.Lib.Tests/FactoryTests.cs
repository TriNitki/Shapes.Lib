using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Lib.Shapes;

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
        var shape = ShapeFactory.CreateShape<Circle>(3, 4, 5);
        var area = shape.CalculateArea();

        Assert.AreEqual(Math.PI * 9, area, Delta);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestShapeFactoryInvalidParameters()
    {
        ShapeFactory.CreateShape(ShapeEnum.Triangle, 3, 2);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
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