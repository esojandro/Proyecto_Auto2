using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Proyecto_Auto.Test
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Llamado al driver que a a utilizar
            var options = new EdgeOptions();
            driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [TearDown] 
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
