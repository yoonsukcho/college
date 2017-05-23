using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
/// <summary>
/// PROG2070-17W-Sec4-Programming: Software Quality Assurance
/// Assignment1 - Test Program
/// 
/// Yoonsuk Cho #7135551
/// Feb 02, 2017
/// </summary>
namespace YChoAssignment01.Tests
{
    [TestClass]
    public class SquareTests
    {

        /// <summary>
        /// test of GetSide method
        /// </summary>
        [Test]
        public void GetSideTest()
        {
            Square sq = new Square(5);
            int side = sq.GetSide();
            NUnit.Framework.Assert.AreEqual(5, side);
        }

        /// <summary>
        /// test of ChangeSide method
        /// </summary>
        [Test]
        public void ChangeSideTest()
        {
            Square sq = new Square(5);
            int side = sq.ChangeSide(4);
            NUnit.Framework.Assert.AreEqual(4, side);
        }

        /// <summary>
        /// test of GetPerimeter method
        /// </summary>
        [Test]
        public void GetPerimeterTest()
        {
            Square sq = new Square(5);
            int side = sq.GetPerimeter();
            NUnit.Framework.Assert.AreEqual(20, side);
        }

        /// <summary>
        /// test of GetPerimeter method
        /// </summary>
        [Test]
        public void GetAreaTest()
        {
            Square sq = new Square(5);
            int side = sq.GetArea();
            NUnit.Framework.Assert.AreEqual(25, side);
        }

    }
}
