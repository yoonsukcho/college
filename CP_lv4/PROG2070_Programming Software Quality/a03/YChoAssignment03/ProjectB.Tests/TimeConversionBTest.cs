using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
/// <summary>
/// PROG2070 – Quality Assurance: Winter 2017
/// Assignment 03
/// Yoonsuk Cho Mar 14, 2017
/// </summary>
namespace ProjectB.Tests
{
    /// <summary>
    /// main class of assignment 3
    /// Project B - Test Program
    /// This class tests Program class of Project B
    /// </summary>
    [TestClass]
    public class TimeConversionBTest
    {
        /// <summary>
        /// This method tests equal case of 
        /// Convert method With ModifyInput And GetMultiplierStub method Test
        /// of TimeConversion class
        /// </summary>
        /// <param name="time">input time value</param>
        /// <param name="convertFrom">time unit convert from</param>
        /// <param name="convertTo">time unit convert to</param>
        /// <param name="expectedValue">expected return time value</param>
        
        // input: 1.0, hours, seconds, return: 1.
        [TestCase(1.0, "hours", "Seconds", 1)]
        // input: 36, minutes, s, return: 36.
        [TestCase(36, "minutes", "s", 36)]
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
        /// Convert method With ModifyInput And GetMultiplierStub method Test
        /// of TimeConversion class
        /// </summary>
        /// <param name="time">input time value</param>
        /// <param name="convertFrom">time unit convert from</param>
        /// <param name="convertTo">time unit convert to</param>
        /// <param name="expectedValue">expected return time value</param>
        
        // input: 1.0, hours, seconds, return: 3600.
        [TestCase(1.0, "Hours", "Seconds", 3600)]
        public void ConvertAreNotEqualTest(double time, 
                                           string convertFrom, 
                                           string convertTo, 
                                           double expectedValue)
        {
            double returnValue = TimeConversion.Convert(time, convertFrom, convertTo);
            NUnit.Framework.Assert.AreNotEqual(returnValue, expectedValue);
        }

        /// <summary>
        /// This method tests Exception case of 
        /// Convert method With ModifyInput method Test
        /// of TimeConversion class
        /// This checks Exception type and message
        /// </summary>
        /// <param name="time">input time value</param>
        /// <param name="convertFrom">time unit convert from</param>
        /// <param name="convertTo">time unit convert to</param>
        /// <param name="expectedMessage">expected Message of Exception</param>

        [TestCase(1.0, "HHH", "Seconds", "Incorrect time unit")]
        public void ConvertThrowsExcpetionTest(double time, 
                                               string convertFrom, 
                                               string convertTo, 
                                               string expectedMessage)
        {
            // the ArgumentException we expect thrown from the TimeConversion.Convert method
            var exception = NUnit.Framework.Assert.Throws<ArgumentException>(() => 
                                    TimeConversion.Convert(time, convertFrom, convertTo));

            // now we can test the exception itself
            NUnit.Framework.Assert.That(exception.Message == expectedMessage);

        }

    }
}
