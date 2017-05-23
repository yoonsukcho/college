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
namespace ProjectC
{
    /// <summary>
    /// Time Conversion class of assignment 3
    /// </summary>
    public static class TimeConversion
    {
        /// <summary>
        /// get converted time value 
        /// from convertFrom time unit to convertTo time unit
        /// with ModifyInput and GetMultiplier
        /// </summary>
        /// <param name="value">numeric time value</param>
        /// <param name="convertFrom">time unit convert From</param>
        /// <param name="convertTo">time unit convert to</param>
        /// <returns></returns>
        public static double Convert(double value,
                                     string convertFrom,
                                     string convertTo)
        {

            convertFrom = ModifyInput(convertFrom);
            convertTo = ModifyInput(convertTo);

            double multiplier = GetMultiplier(convertFrom, convertTo);

            return value / multiplier;
        }

        /// <summary>
        /// modify time unit 
        /// from various input time unit 
        /// to specific time unit sign for multiply
        /// </summary>
        /// <param name="input">input time unit</param>
        /// <returns>specific time unit sign</returns>
        private static string ModifyInput(string input)
        {
            string returnValue = "";
            switch (input)
            {
                case "seconds":
                case "Seconds":
                case "s":
                case "S":
                    returnValue = "seconds";
                    break;
                case "minutes":
                case "Minutes":
                case "m":
                case "M":
                    returnValue = "minutes";
                    break;
                case "hours":
                case "Hours":
                case "h":
                case "H":
                    returnValue = "hours";
                    break;
                case "days":
                case "Days":
                case "d":
                case "D":
                    returnValue = "days";
                    break;
                default:
                    throw new ArgumentException("Incorrect time unit");
            }

            return returnValue;
        }

        /// <summary>
        /// get multiplier factor 
        /// using convertFrom time unit to convertTo time unit
        /// </summary>
        /// <param name="convertFrom">convert From time unit</param>
        /// <param name="convertTo">convert To time unit</param>
        /// <returns></returns>
        private static double GetMultiplier(string convertFrom,
                                            string convertTo)
        {
            double returnValue = 1.0d;

            Dictionary<string, int> indexes = new Dictionary<string, int>();
            indexes.Add("seconds", 0);
            indexes.Add("minutes", 1);
            indexes.Add("hours", 2);
            indexes.Add("days", 3);

            int[] multi = new int[] { 60, 60, 24 };

            int startIdx = indexes[convertFrom];
            int lastIdx = indexes[convertTo];

            if (startIdx < lastIdx)
            {
                for (int i = startIdx; i < lastIdx; i++)
                {
                    returnValue *= multi[i];
                }
            }
            else
            {
                for (int i = lastIdx; i < startIdx; i++)
                {
                    returnValue /= multi[i];
                }

            }

            return returnValue;
        }

    }
}
