using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// PROG2070 – Quality Assurance: Winter 2017
/// Assignment 02
/// Yoonsuk Cho Feb 14, 2017
/// </summary>
namespace YChoAssignment02
{
    /// <summary>
    /// subclass of main class
    /// this class would classify the type of triangle or not
    /// </summary>
    public class TriangleSolver
    {
        private static string[] msgs = {  "This is a scalene triangle.",
                                          "This is an isosceles triangle.",
                                          "This is an equilateral triangle.",
                                          "This is not a triangle." };
        /// <summary>
        /// Analyze the triangle sides 
        /// using 3 sides of triangle which are parameters of method
        /// this method will calculate the type of triangle
        /// There are 4 type of messages
        /// 1. This is not a triangle.
        /// 2. This is a scalene triangle.
        /// 3. This is an isosceles triangle.
        /// 4. This is an equilateral triangle.
        /// </summary>
        /// <param name="sides">3 sides of triangle</param>
        /// <returns>result type of triangle</returns>
        public static string Analyze(int[] sides)
        {
            string message = "";
            // one side is bigger or eaual to sum of other 2 sides
            if (sides[0] >= sides[1] + sides[2])
            {
                // not a triangle
                message = msgs[3];
                Console.WriteLine("No!");
            }
            // one side is bigger or eaual to sum of other 2 sides
            else if (sides[1] >= sides[2] + sides[0])
            {
                // not a triangle
                message = msgs[3];
                Console.WriteLine("No!");
            }
            // one side is bigger or eaual to sum of other 2 sides
            else if (sides[2] >= sides[0] + sides[1])
            {
                // not a triangle
                message = msgs[3];
                Console.WriteLine("No!");
            }
            else
            {
                Console.WriteLine("Yes!");
                // all 3 sides are same
                if (sides[0] == sides[1] && sides[1] == sides[2])
                {
                    // an equilateral triangle
                    message = msgs[2];
                }
                // 2 sides are same, but the other is different
                else if (sides[0] == sides[1])
                {
                    // an isosceles triangle
                    message = msgs[1];
                }
                else if (sides[1] == sides[2])
                {
                    // an isosceles triangle
                    message = msgs[1];
                }
                else if (sides[0] == sides[2])
                {
                    // an isosceles triangle
                    message = msgs[1];
                }
                else
                {
                    // all sides are different each other
                    // a scalene triangle
                    message = msgs[0]; ;
                }
            }
            return message;
        }

    }
}
