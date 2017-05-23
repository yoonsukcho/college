using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
/// <summary>
/// PROG2070-17W-Sec4-Programming: Software Quality Assurance
/// Assignment02 - Test Program
/// 
/// Yoonsuk Cho #7135551
/// Feb 14, 2017
/// </summary>
namespace YChoAssignment02.Tests
{
    /// <summary>
    /// NUnit Test class
    /// This class tests TriangleSolver class
    /// </summary>
    [TestClass]
    public class TriangleSolverTest
    {

        /// <summary>
        /// This method tests various case of 
        /// Analyze method of TriangleSolver class
        /// </summary>
        /// <param name="side1">one side of triangle</param>
        /// <param name="side2">one side of triangle</param>
        /// <param name="side3">one side of triangle</param>
        /// <param name="msg">expected return message</param>
        
        // not a triangle: The 3rd side is not greater than sum of rest 2 sides.
        [TestCase(2, 2, 4, "This is not a triangle.")]
        // not a triangle: The 1st side is not greater than sum of rest 2 sides.
        [TestCase(5, 2, 2, "This is not a triangle.")]
        // not a triangle: The 2nd side is not greater than sum of rest 2 sides.
        [TestCase(2, 6, 4, "This is not a triangle.")]
        // scalene triangle: All 3 sides are different each other.
        [TestCase(4, 2, 3, "This is a scalene triangle.")]
        // isosceles triangle: The 1st and 2nd sides are same.
        [TestCase(3, 3, 4, "This is an isosceles triangle.")]
        // isosceles triangle: The 3rd and 2nd sides are same.
        [TestCase(3, 4, 4, "This is an isosceles triangle.")]
        // isosceles triangle: The 1st and 3rd sides are same.
        [TestCase(4, 3, 4, "This is an isosceles triangle.")]
        // equilateral triangle: All 3 sides are same.
        [TestCase(3, 3, 3, "This is an equilateral triangle.")]
        public void AnalyzeTest(int side1, int side2, int side3, string msg)
        {
            string message = TriangleSolver.Analyze(new int[] { side1, side2, side3 });
            NUnit.Framework.Assert.AreEqual(msg, message);
        }
    }
}
