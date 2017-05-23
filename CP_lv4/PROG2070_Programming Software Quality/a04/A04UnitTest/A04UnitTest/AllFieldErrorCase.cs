using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
/// <summary>
/// PROG2070-17W-Sec4-Programming: Software Quality Assurance
/// Assignment4 - Test Program (Error Case)
/// 
/// Yoonsuk Cho #7135551
/// Apr 13, 2017
/// </summary>
namespace A04UnitTest
{
    [TestFixture]
    public class AllFieldErrorCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService("c:\\selenium-dotnet-3.3.0\\net40\\");
            driver = new FirefoxDriver(service);

            baseURL = "http://127.0.0.1:63140/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void AllFieldErrorCaseTest()
        {
            //driver.Navigate().GoToUrl(baseURL + "/index.html");
            //driver.FindElement(By.Id("inputPage")).Click();
            driver.Navigate().GoToUrl(baseURL + "/input.html");
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys("Seller Error");
            driver.FindElement(By.Id("testBtn")).Click();
            Assert.AreEqual("Please check the mandatory field. [Address].\r\nPlease check the mandatory field. [City].\r\nPlease check the mandatory field. [Phone Number].\r\nPlease check the mandatory field. [eMail].\r\nPlease check the mandatory field. [Vehicle make].\r\nPlease check the mandatory field. [Vehicle model].\r\nPlease check the mandatory field. [Vehicle year].\r\nWrong format error. [Phone Number - ex) 123-456-7890].\r\n", CloseAlertAndGetItsText());
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
