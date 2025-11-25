using OpenQA.Selenium;

namespace Proyecto_Auto.Page
{
    public class LoginPage : BasePage
    {
        private By UserNameInput = By.Id("username");
        private By PassInput = By.Id("password");
        private By SubmitButton = By.Id("submit");

        private By MsgLoginExitoso = By.CssSelector("p[class='has-text-align-center'] strong");
        private By MsgLoginErroneo = By.CssSelector("#error");

        public LoginPage(IWebDriver driver) : base(driver) {  }

        public void ingresarUsuario(string usuario)
        {
            ingresrTbx(UserNameInput, usuario);
        }

        public void ingresarPass(string pass)
        {
            ingresrTbx(PassInput, pass);
        }

        public void clickSubmit()
        {
            clickBtn(SubmitButton);
        }

        public string getMsgLoginExitoso()
        {
            return obtenerTexto(MsgLoginExitoso);
        }

        public string getMsgLoginErroneo()
        {
            return obtenerTexto(MsgLoginErroneo);
        }

        public void login(string usuario, string pass)
        {
            ingresarUsuario(usuario);
            ingresarPass(pass);
            clickSubmit();
        }
    }
}
