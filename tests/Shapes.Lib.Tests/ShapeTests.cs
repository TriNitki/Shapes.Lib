using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Lib.Shapes;

namespace Shapes.Lib.Tests;

[TestClass]
public class ShapeTests
{
    private const double Delta = 1e-10;

    [TestMethod]
    public void TestCircleArea()
    {
        var circle = new Circle(5);

        var area = circle.CalculateArea();

        Assert.AreEqual(Math.PI * 25, area);
    }

    [TestMethod]
    public void TestTriangleArea()
    {
        var triangle = new Triangle(3, 4, 5);

        var area = triangle.CalculateArea();

        Assert.AreEqual(6, area, Delta);
    }

    [TestMethod]
    public void TestRightTriangleCheck()
    {
        var triangle = new Triangle(3, 4, 5);

        var isRight = triangle.IsRightTriangle();

        Assert.IsTrue(isRight);
    }

    [TestMethod]
    public void TestNotRightTriangleCheck()
    {
        var triangle = new Triangle(2, 4, 5);

        var isRight = triangle.IsRightTriangle();

        Assert.IsFalse(isRight);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidCircle()
    {
        new Circle(-1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidTriangle()
    {
        new Triangle(-1, 2, 3);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestInvalidTriangleSidesAmount()
    {
        new Triangle(1, 2);
    }

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
}