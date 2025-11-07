using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

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
        [Ignore("Test de navegacion ignorado")]
        public void TestNavegar()
        {
            driver.Navigate().GoToUrl("https://www.bing.com");
        }

        // Se realiza un login exitoso, una aserción para validar el login
        [Test]
        public void loginExitoso()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login");
            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.Id("password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();

            // Se explica luego los tiempos Implicitos
            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.CssSelector("p[class='has-text-align-center'] strong")).Displayed, Is.True);
        }

        // Practica: crear dos test de login erroneo ----------------------------------------------------

        [Test]
        public void loginErroneoPass()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login");
            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.Id("password")).SendKeys("123");
            driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.CssSelector("#error")).Displayed, Is.True);
        }

        [Test]
        public void loginErroneoUsr()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login");
            driver.FindElement(By.Id("username")).SendKeys("studt");
            driver.FindElement(By.Id("password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.CssSelector("#error")).Displayed, Is.True);
        }
        // Fin practica --------------------------------------------------------------------------------

        // Explicación soenre recibir variables desde etiquetas
        [TestCase("student", "Password123", true)]
        [TestCase("studt", "Password123", false)]
        [TestCase("student", "123", false)]
        public void loginTresEscenarios(string usr, string pass, bool resultado)
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login");
            driver.FindElement(By.Id("username")).SendKeys(usr);
            driver.FindElement(By.Id("password")).SendKeys(pass);
            driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(2000);
            bool loginExitoso = driver.PageSource.Contains("Logged In Successfully");
            Assert.That(loginExitoso, Is.EqualTo(resultado));
        }

        // Se interactua con una Text Box y asserciones
        [Test]
        public void interactuarTxBox()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            driver.FindElement(By.Id("userName")).SendKeys("Juan Perez");
            driver.FindElement(By.Id("userEmail")).SendKeys("mail@mail.com");
            driver.FindElement(By.Id("currentAddress")).SendKeys("Calle Falsa 123");
            driver.FindElement(By.Id("permanentAddress")).SendKeys("Calle Verdadera 456");
            driver.FindElement(By.Id("submit")).Click();

            //Aserciones
            Assert.That(driver.FindElement(By.Id("name")).Text, Is.EqualTo("Name:Juan Perez"));
            Assert.That(driver.FindElement(By.Id("email")).Text, Is.EqualTo("Email:mail@mail.com"));
            Assert.That(driver.FindElement(By.CssSelector("p[id='currentAddress']")).Text, Is.EqualTo("Current Address :Calle Falsa 123"));
            Assert.That(driver.FindElement(By.CssSelector("p[id='permanentAddress']")).Text, Is.EqualTo("Permananet Address :Calle Verdadera 456"));
        }

        [Test]
        public void interactuarCheckBox()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/checkbox");
            // Expandir las opciones
            driver.FindElement(By.XPath("//button[@title='Toggle']")).Click();
            driver.FindElement(By.XPath("//li[3]//span[1]//button[1]")).Click();

            // Seleccionar la opcion Excel
            driver.FindElement(By.CssSelector("label[for='tree-node-excelFile']")).Click();

            // Asercion
            Assert.That(driver.FindElement(By.CssSelector(".text-success")).Text, Is.EqualTo("excelFile"));
        }

        [Test]
        public void interactuarDDl()
        {
            driver.Navigate().GoToUrl("https://letcode.in/dropdowns");
            SelectElement selectFruit = new SelectElement(driver.FindElement(By.Id("fruits")));
            selectFruit.SelectByText("Banana");

            Assert.That(selectFruit.SelectedOption.Text, Is.Not.EqualTo("Apple"));
            Assert.That(driver.FindElement(By.XPath("//div[@class='card-content']//div[1]//div[1]//div[2]//div[1]")).Text, 
                Is.EqualTo("You have selected Banana"));
        }

        [TearDown] //**** Uso de copilot para solucionarlo!
        public void TearDown() 
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}