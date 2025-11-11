using Proyecto_Auto.Page;

namespace Proyecto_Auto.Test
{
    public class LoginTest : BaseTest
    {
        public void navegar()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login");
        }

        [Test]
        public void loginExitoso()
        {
            try
            {
                navegar();
                LoginPage pom = new LoginPage(driver);
                pom.ingresarUsuario("student");
                pom.ingresarPass("Password123");
                pom.clickSubmit();
                Assert.That(pom.getMsgLoginExitoso(), Is.EqualTo("Congratulations student. You successfully logged in!"));
                Assert.That(driver.Url, Is.EqualTo("https://practicetestautomation.com/logged-in-successfully/"));
            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }
        }

        public void loginWrongUsr()
        {
            try
            {
                navegar();
                LoginPage pom = new LoginPage(driver);
                pom.login("studt", "Password123");
                Assert.That(pom.getMsgLoginErroneo(), Is.EqualTo("Your username is invalid!"));                
            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }
        }

        public void loginWrongPass()
        {
            try
            {
                navegar();
                LoginPage pom = new LoginPage(driver);
                pom.login("student", "Password");
                Assert.That(pom.getMsgLoginErroneo(), Is.EqualTo("Your password is invalid!"));
            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }
        }
    }
}
