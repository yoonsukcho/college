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
/// Assignment4 - Test Program (Normal Case)
/// 
/// Yoonsuk Cho #7135551
/// Apr 13, 2017
/// </summary>
namespace A04UnitTest
{
    [TestFixture]
    public class NormalInputSuccessCase
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
        public void NormalInputSuccessCaseTest()
        {
            //driver.Navigate().GoToUrl(baseURL + "/index.html");
            //driver.FindElement(By.Id("listPage")).Click();
            //driver.FindElement(By.Id("testBtn")).Click();
            //driver.FindElement(By.Id("inputPage")).Click();
            driver.Navigate().GoToUrl(baseURL + "/input.html");

            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys("Sellor abc");
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys("99 avenue street");
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("guelph");
            driver.FindElement(By.Id("phoneNumber")).Clear();
            driver.FindElement(By.Id("phoneNumber")).SendKeys("987-654-4321");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("akakak@kkkd.net");
            driver.FindElement(By.Id("make")).Clear();
            driver.FindElement(By.Id("make")).SendKeys("Ford");
            driver.FindElement(By.Id("model")).Clear();
            driver.FindElement(By.Id("model")).SendKeys("mustang");
            driver.FindElement(By.Id("year")).Clear();
            driver.FindElement(By.Id("year")).SendKeys("2011");
            driver.FindElement(By.Id("testBtn")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [waitForPopUp |  | 30000]]
            //driver.FindElement(By.Id("testBtn2")).Click();
            //driver.FindElement(By.Id("listPage")).Click();
            //driver.FindElement(By.Id("testBtn")).Click();
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
