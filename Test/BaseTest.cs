using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Proyecto_Auto.Test
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected ExtentTest test;
        private static AventStack.ExtentReports.ExtentReports extent;
        public string usrname = "";
        public string passwrd = "";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Console.WriteLine("🚀 OneTimeSetUp ejecutado");

            var reportPath = @"C:\Users\Alejandro\source\repos\Proyecto_Auto\Reportes";
            Directory.CreateDirectory(reportPath);

            // usar nombres totalmente cualificados para evitar conflictos de namespace
            var spark = new AventStack.ExtentReports.Reporter.ExtentHtmlReporter(Path.Combine(reportPath, "ReporteAutomatizacion.html"));

            // declarar e instanciar también con nombre totalmente calificado
            AventStack.ExtentReports.ExtentReports extentLocal = new AventStack.ExtentReports.ExtentReports();
            extentLocal.AttachReporter(spark);

            // asignar a tu campo estático (si quieres mantenerlo)
            extent = extentLocal;

            Console.WriteLine("📁 Reporte se generará en: " + reportPath);
        }

        [SetUp]
        public void Setup()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            test.Info("Inicializando navegador Edge");
            // Llamado al driver que a a utilizar
            var options = new EdgeOptions();
            options.AddArgument("--headless=new");     // el modo headless clásico está obsoleto
            //options.AddArgument("--disable-gpu");
            //options.AddArgument("--window-size=1920,1080");
            //options.AddArgument("--no-sandbox");
            //options.AddArgument("--disable-dev-shm-usage");
            driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();

            var data = Utils.JsonReader.ReadLoginData();
            usrname = data.username;
            passwrd = data.password;
        }

        public string TomarCaptura(string nombreTest)
        {
            try
            {
                string screenshotsDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Screenshots");
                Directory.CreateDirectory(screenshotsDir);

                string filePath = Path.Combine(screenshotsDir, $"{nombreTest}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filePath);

                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al tomar captura: " + ex.Message);
                return "";
            }
        }

        [TearDown] 
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail("❌ El test falló: " + TestContext.CurrentContext.Result.Message);

                string rutaCaptura = TomarCaptura(TestContext.CurrentContext.Test.Name);

                if (!string.IsNullOrEmpty(rutaCaptura))
                {
                    test.AddScreenCaptureFromPath(rutaCaptura);
                    test.Info("📸 Captura adjunta");
                }
            }
            else
            {
                test.Pass("✔ Test ejecutado correctamente.");
            }

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("🔥 Ejecutando OneTimeTearDown...");
            extent.Flush();
        }
    }
}
