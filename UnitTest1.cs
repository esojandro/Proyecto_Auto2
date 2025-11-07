using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using NUnit.Framework;

namespace Proyecto_Auto
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Llamado al driver que a a utilizar
            var options = new EdgeOptions();
            driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestNavegar()
        {
            driver.Navigate().GoToUrl("https://www.bing.com");
        }

        [Test]
        public void loginExitoso()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login");
            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.Id("password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();
            Assert.That(driver.FindElement(By.CssSelector("p[class='has-text-align-center'] strong")).Displayed, Is.True);
        }

        [Test]
        public void loginErroneoPass()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login");
            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("submit")).Click();
            Assert.That(driver.FindElement(By.CssSelector("#error")).Displayed, Is.True);
        }

        [Test]
        public void loginErroneoUsr()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login");
            driver.FindElement(By.Id("username")).SendKeys("studt");
            driver.FindElement(By.Id("password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();
            Assert.That(driver.FindElement(By.CssSelector("#error")).Displayed, Is.True);
        }

        [TearDown]
        public void TearDown() 
        { 
            driver.Quit();
        }
    }
}