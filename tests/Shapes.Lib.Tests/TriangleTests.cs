using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Lib.Shapes;

namespace Shapes.Lib.Tests;

[TestClass]
public class TriangleTests : BaseTest
{
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
    public void TestEditTriangleSides()
    {
        var triangle = new Triangle(2, 4, 5);
        triangle.Sides = [3, 4, 5];
        var area = triangle.CalculateArea();

        Assert.AreEqual(6, area, Delta);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidTriangle()
    {
        new Triangle(-1, 2, 3);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidEditTriangleSides()
    {
        var triangle = new Triangle(2, 4, 5);
        triangle.Sides = [-1, 4, 5];
    }
}