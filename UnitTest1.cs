using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

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

        [TearDown]

        public void TearDown() 
        { 
            driver.Quit();
        }
    }
}