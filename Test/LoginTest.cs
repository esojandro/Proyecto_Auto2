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
                test.Pass("Se ha navegado correctamente");
                pom.ingresarUsuario(usrname);
                test.Pass("Se ha ingresado el usuario: " + usrname);
                pom.ingresarPass(passwrd);
                test.Pass("Se ha ingresado la contraseña");
                pom.clickSubmit();
                test.Pass("Se ha seleccionado el botón login correctamente");
                Assert.That(pom.getMsgLoginExitoso(), Is.EqualTo("Congratulations student. You successfully logged in!"));
                test.Pass("Se valida el mensaje de login exitoso");
                Assert.That(driver.Url, Is.EqualTo("https://practicetestautomation.com/logged-in-successfully/"));
                test.Pass("Se valida la rura url");
            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }
        }

        [Test]
        public void loginWrongUsr()
        {
            test.Info("Inicia prueba de login con usuario: " + passwrd + " erroneo");
            try
            {
                navegar();
                LoginPage pom = new LoginPage(driver);
                test.Pass("Se ha navegado correctamente");
                pom.login(usrname + "45", passwrd);
                test.Pass("Se ha ingresado el usuario erroneno y contraseña: " + usrname + "45");
                Assert.That(pom.getMsgLoginErroneo(), Is.EqualTo("Your username is invalid!"));
                test.Pass("Se valida el mensaje de login erroeno es: " + pom.getMsgLoginErroneo());
            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }
        }

        [Test]
        public void loginWrongPass()
        {
            test.Info("Inicia prueba de login con pass erroneo");
            try
            {
                navegar();
                LoginPage pom = new LoginPage(driver);
                pom.login(usrname, passwrd + "Wrs");
                test.Pass("Se ha ingresado el usuario y contraseña erronea");
                Assert.That(pom.getMsgLoginErroneo(), Is.EqualTo("Your password is invalid!"));
                test.Pass("Se valida el mensaje de login erroeno es: " + pom.getMsgLoginErroneo());
            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }
        }

        [Test]
        public void loginWrongCaptura()
        {
            test.Info("Inicia prueba de login con pass erroneo");
            try
            {
                navegar();
                LoginPage pom = new LoginPage(driver);
                pom.login(usrname, passwrd + "Wrs");
                test.Pass("Se ha ingresado el usuario y contraseña erronea");
                Assert.That(pom.getMsgLoginErroneo(), Is.EqualTo("Your password"));
                test.Pass("Se valida el mensaje de login erroeno es: " + pom.getMsgLoginErroneo());
            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }
        }
    }
}
