using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTests.Pages
{
    public class AhorcadoPage
    {
        public IWebDriver WebDriver { get; }
        public WebDriverWait WebDriverWait { get; }

        public AhorcadoPage(IWebDriver webDriver, WebDriverWait webDriverWait)
        {
            WebDriver = webDriver;
            WebDriverWait = webDriverWait;
        }

        public IWebElement btnTest => WebDriverWait.Until(x => x.FindElement(By.Id("btnTest")));
        public IWebElement btnArriesgarLetra => WebDriver.FindElement(By.Id("btnArriesgarLetra"));
        public IWebElement btnArriesgarPalabra => WebDriver.FindElement(By.Id("btnArriesgarPalabra"));
        public IWebElement txtLetra => WebDriver.FindElement(By.Id("txtLetra"));
        public IWebElement txtPalabra => WebDriver.FindElement(By.Id("txtPalabra"));
        public IWebElement divErrorMessage => WebDriverWait.Until(x => x.FindElement(By.Id("errorMessage")));
        public IWebElement divWinMessage => WebDriverWait.Until(x => x.FindElement(By.Id("winMessage")));
        public IWebElement divGameOverMessage => WebDriverWait.Until(x => x.FindElement(By.Id("gameOverMessage")));

        public void ClickTesting() => btnTest.Click();
        public void ClickArriesgarLetra() => btnArriesgarLetra.Click();
        public void ClickArriesgarPalabra() => btnArriesgarPalabra.Click();

        public void EnterLetra(string letra)
        {
            txtLetra.SendKeys(letra);
        }

        public void EnterPalabra(string palabra)
        {
            txtPalabra.SendKeys(palabra);
        }

        public bool IsErrorMessageDisplayed() => divErrorMessage.Displayed;
        public bool IsWinMessageDisplayed() => divWinMessage.Displayed;
        public bool IsGameOverMessageDisplayed() => divGameOverMessage.Displayed;

        public void Close()
        {
            WebDriver.Close();
            WebDriver.Dispose();
            WebDriver.Quit();
        }
    }
}
