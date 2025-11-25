using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Proyecto_Auto.Page
{
    public class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public BasePage(IWebDriver driver) 
        { 
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void ingresrTbx(By selector, string texto)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
            driver.FindElement(selector).Clear();
            driver.FindElement(selector).SendKeys(texto);            
        }

        public void clickBtn(By selector)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(selector));
            driver.FindElement(selector).Click();
        }

        public string obtenerTexto(By selector)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(selector));
            return driver.FindElement(selector).Text;
        }
    }
}
