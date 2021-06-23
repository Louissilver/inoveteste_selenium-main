using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace InoveTeste.Comandos
{
    class Comandos
    {
        #region Navegador
        public static IWebDriver Navegador(IWebDriver driver, string navegador)
        {
            switch (navegador)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    driver.Navigate().GoToUrl("https://static.gordiansoftware.com/");
                    driver.Manage().Window.Maximize();
                    break;
                case "Internet Explorer":
                    driver.Navigate().GoToUrl("https://static.gordiansoftware.com/");
                    driver = new InternetExplorerDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case "FireFox":
                    driver = new FirefoxDriver();
                    driver.Navigate().GoToUrl("https://static.gordiansoftware.com/");
                    driver.Manage().Window.Maximize();
                    break;
            }
            return driver;
        }
        #endregion

        #region Javascript
        public static void ExecutarJavaScript(IWebDriver driver, string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script);
        }
        #endregion
    }
}
