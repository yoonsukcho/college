using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// PROG2070 – Quality Assurance: Winter 2017
/// Assignment 03
/// Yoonsuk Cho Mar 14, 2017
/// </summary>
namespace ProjectA
{
    /// <summary>
    /// Time Conversion class of assignment 3
    /// </summary>
    public static class TimeConversion
    {
        /// <summary>
        /// get converted time value 
        /// from convertFrom time unit to convertTo time unit
        /// with ModifyInputStub(fixed return) and GetMultiplierStub(fixed return)
        /// </summary>
        /// <param name="value">numeric time value</param>
        /// <param name="convertFrom">time unit convert From</param>
        /// <param name="convertTo">time unit convert to</param>
        /// <returns></returns>
        public static double Convert(double value,
                                     string convertFrom,
                                     string convertTo)
        {

            convertFrom = ModifyInputStub(convertFrom);
            convertTo = ModifyInputStub(convertTo);

            double multiplier = GetMultiplierStub(convertFrom, convertTo);

            return value / multiplier;
        }

        /// <summary>
        /// modify time unit 
        /// from various input time unit 
        /// to specific time unit sign for multiply
        /// this method will return fixed value
        /// </summary>
        /// <param name="input">input time unit</param>
        /// <returns>specific time unit sign</returns>
        private static string ModifyInputStub(string input)
        { 
            return "seconds";
        }

        /// <summary>
        /// get multiplier factor 
        /// using convertFrom time unit to convertTo time unit
        /// this method will return fixed value
        /// </summary>
        /// <param name="convertFrom">convert From time unit</param>
        /// <param name="convertTo">convert To time unit</param>
        /// <returns></returns>
        private static double GetMultiplierStub(string convertFrom,
                                            string convertTo)
        {
            return 1.0d;
        }

    }
}
