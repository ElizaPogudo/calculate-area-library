using MathAreaTest.Entities;
using MathArea;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathArea.Shapes;
using System.Collections.Generic;
using System.Linq;

namespace MathAreaTest
{
    [TestClass]
    public class MathAreaUnitTest
    {
        [TestMethod]
        public void GetAreaOfCustomShape() 
        {
            //act
            double result = MathArea.MathArea.GetArea(new CustomShape(6, 7.09));
            //assert
            Assert.AreEqual(42.54d, result);
        }

        [TestMethod]
        public void CreateCircleWithRadiusLessThanZero()
        {
            try
            {
                var circle = new Circle(-5.6d);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Радиус круга должен быть больше нуля.", ex.Message);
            }
        }

        [TestMethod]
        public void GetCircleArea()
        {
            //init
            double radius = 1.6d;
            var circle = new Circle(radius);
            //act
            var result = circle.GetArea();
            //assert
            Assert.AreEqual(Math.PI * Math.Pow(radius, 2), result);
        }

        [TestMethod]
        public void CreateUnExistingTriangle()
        {
            //init
            var testSides = new List<double>() { 2.3d, 5.5d, 8d };
            try
            {
                //act
                var triangle = new Triangle(testSides);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Такого треугольника не существует..", ex.Message);
            }
        }

        [TestMethod]
        public void GetTriangleAreaUsingThreeSides()
        {
            //init
            var testSides = new List<double>() { 4d, 7d, 8d };
            var triangle = new Triangle(testSides);
            //act
            var result = triangle.GetArea();
            //assert
            Assert.AreEqual(13.9978d, Math.Round(result,4));
        }

        [TestMethod]
        public void GetRectangleTriangleArea()
        {
            //init
            var testSides = new List<double>() { 4.5d, 5.41d, 3d };
            var triangle = new Triangle(testSides);
            //act
            var result = triangle.GetArea();
            //assert
            Assert.AreEqual(6.75d, Math.Round(result, 4));
        }

        [TestMethod]
        public void GetTriangleAreaUsingPoints()
        {
            //init
            var testPoints = new List<Point>() { new Point { X = -7, Y = 5 }, new Point { X = -3, Y = -5 }, new Point { X = 8, Y = 7 } };
            var triangle = new Triangle(testPoints);
            //act
            var result = triangle.GetArea();
            //assert
            Assert.AreEqual(79d, Math.Round(result, 4));
        }

    }
}
