using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Lib.Shapes;

namespace Shapes.Lib.Tests;

[TestClass]
public class CircleTests : BaseTest
{
    [TestMethod]
    public void TestCircleArea()
    {
        var circle = new Circle(5);
        var area = circle.CalculateArea();

        Assert.AreEqual(Math.PI * 25, area, Delta);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidCircle()
    {
        new Circle(-1);
    }

    [TestMethod]
    public void TestEditCircleRadius()
    {
        var circle = new Circle(5);
        circle.Radius = 3;
        var area = circle.CalculateArea();

        Assert.AreEqual(Math.PI * 9, area, Delta);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidEditCircleRadius()
    {
        var circle = new Circle(5);
        circle.Radius = -1;
    }
}