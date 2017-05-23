using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// PROG2070-17W-Sec4-Programming: Software Quality Assurance
/// Assignment1 - Square module
/// 
/// Yoonsuk Cho #7135551
/// Feb 02, 2017
/// </summary>
namespace YChoAssignment01
{
    public class Square
    {
        private int side = 0;

        /// <summary>
        /// default constructor
        /// without parameter
        /// default value is 1
        /// </summary>
        public Square()
        {
            this.side = 1;
        }

        /// <summary>
        /// additional constructor
        /// with parameter
        /// parameter is a side
        /// </summary>
        public Square(int side)
        {
            this.side = side;
        }

        /// <summary>
        /// get a side of square
        /// </summary>
        /// <returns>side</returns>
        public int GetSide()
        {
            return side;
        }

        /// <summary>
        /// change a side of square
        /// </summary>
        /// <param name="side">side to be changed</param>
        /// <returns>side changed</returns>
        public int ChangeSide(int side)
        {
            this.side = side;
            return side;
        }

        /// <summary>
        /// get a perimeter of square
        /// </summary>
        /// <returns>perimeter</returns>
        public int GetPerimeter()
        {
            return side * 4;
        }

        /// <summary>
        /// get an area of square
        /// </summary>
        /// <returns>area</returns>
        public int GetArea()
        {

            return side * side;
        }


    }
}
