using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ProjectC.Tests
{
    [TestClass]
    public class TimeConversionCTest
    {
        /// <summary>
        /// This method tests equal case of 
        /// Convert method With ModifyInput And GetMultiplierb method Test
        /// of TimeConversion class
        /// </summary>
        /// <param name="time">input time value</param>
        /// <param name="convertFrom">time unit convert from</param>
        /// <param name="convertTo">time unit convert to</param>
        /// <param name="expectedValue">expected return time value</param>
        /// 
        // input: 1.0, hours, seconds, return: 3600.
        [TestCase(1.0, "hours", "Seconds", 3600)]
        // input: 36, minutes, s, return: 2160.
        [TestCase(36, "minutes", "s", 2160)]
        // input: 4320, m, Days, return: 3.
        [TestCase(4320, "m", "Days", 3)]
        // input: 7200, S, Hours, return: 2.
        [TestCase(7200, "S", "Hours", 2)]
        public void ConvertAreEqualTest(double time,
                                        string convertFrom,
                                        string convertTo,
                                        double expectedValue)
        {
            double returnValue = TimeConversion.Convert(time, convertFrom, convertTo);
            NUnit.Framework.Assert.AreEqual(returnValue, expectedValue);
        }

    }
}
