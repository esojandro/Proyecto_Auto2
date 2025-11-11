using OpenQA.Selenium;

namespace Proyecto_Auto.Page
{
    public class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver) { this.driver = driver;  }

        public void ingresrTbx(By selector, string texto)
        {
            driver.FindElement(selector).SendKeys(texto);
        }

        public void clickBtn(By selector)
        {
            driver.FindElement(selector).Click();
        }

        public string obtenerTexto(By selector)
        {
            return driver.FindElement(selector).Text;
        }
    }
}
