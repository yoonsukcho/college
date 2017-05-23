using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
/// <summary>
/// PROG2070 – Quality Assurance: Winter 2017
/// Assignment 03
/// Yoonsuk Cho Mar 14, 2017
/// </summary>
namespace ProjectA.Tests
{
    /// <summary>
    /// main class of assignment 3
    /// Project A - Test Program
    /// This class tests Program class of Project A
    /// </summary>
    [TestClass]
    public class TimeConversionATest
    {
        /// <summary>
        /// This method tests equal case of 
        /// Convert method With ModifyInputStub And GetMultiplierStub method Test
        /// of TimeConversion class
        /// </summary>
        /// <param name="time">input time value</param>
        /// <param name="convertFrom">time unit convert from</param>
        /// <param name="convertTo">time unit convert to</param>
        /// <param name="expectedValue">expected return time value</param>
        /// 
        // input: 1.0, hours, seconds, return: 1.
        [TestCase(1.0, "Hours", "Seconds", 1)]
        // input: 36, SSS, HHH, return: 36.
        [TestCase(36, "SSS", "HHH", 36)]
        public void ConvertAreEqualTest(double time, 
                                        string convertFrom, 
                                        string convertTo, 
                                        double expectedValue)
        {
            double returnValue = TimeConversion.Convert(time, convertFrom, convertTo);
            NUnit.Framework.Assert.AreEqual(returnValue, expectedValue);
        }

        /// <summary>
        /// This method tests not equal case of 
        /// Convert method With ModifyInputStub And GetMultiplierStub method Test
        /// of TimeConversion class
        /// </summary>
        /// <param name="time">input time value</param>
        /// <param name="convertFrom">time unit convert from</param>
        /// <param name="convertTo">time unit convert to</param>
        /// <param name="expectedValue">expected return time value</param>
        /// 
        // input: 1.0, hours, seconds, return: 1.
        [TestCase(1.0, "Hours", "Seconds", 3600)]
        // input: 36, HHH, DDD, return: 36.
        [TestCase(36, "HHH", "DDD", 3)]
        public void ConvertAreNotEqualTest(double time, 
                                           string convertFrom, 
                                           string convertTo, 
                                           double expectedValue)
        {
            double returnValue = TimeConversion.Convert(time, convertFrom, convertTo);
            NUnit.Framework.Assert.AreNotEqual(returnValue, expectedValue);
        }
    }
}
