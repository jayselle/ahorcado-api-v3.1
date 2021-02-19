using AcceptanceTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public sealed class AhorcadoSteps
    {
        // Anti-Context Injection Code - 100% wrong
        AhorcadoPage ahorcadoPage = null;

        [BeforeScenario]
        public void TestInitialize()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://ahorcado-web-v3-1.herokuapp.com/");
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            ahorcadoPage = new AhorcadoPage(webDriver, webDriverWait);
        }

        [Given(@"Seteo testing como la palabra a adivinar")]
        public void GivenSeteoTestingComoLaPalabraAAdivinar()
        {
            ahorcadoPage.ClickTesting();
        }

        [When(@"Ingreso la palabra '(.*)'")]
        public void WhenIngresoLaPalabra(string palabra)
        {
            ahorcadoPage.EnterPalabra(palabra);
            ahorcadoPage.ClickArriesgarPalabra();
        }

        [When(@"Ingreso letras '(.*)'")]
        public void WhenIngresoLetras(string ls)
        {
            var letras = new List<string>(ls.Split(','));

            letras.ForEach(l =>
            {
                ahorcadoPage.EnterLetra(l);
                ahorcadoPage.ClickArriesgarLetra();
            });
        }

        [Then(@"Deberia ver el mensaje de que gane")]
        public void ThenDeberiaVerElMensajeDeQueGane()
        {
            Assert.That(ahorcadoPage.IsWinMessageDisplayed(), Is.True);
        }

        [Then(@"Deberia ver el mensaje de que perdi")]
        public void ThenDeberiaVerElMensajeDeQuePerdi()
        {
            Assert.That(ahorcadoPage.IsGameOverMessageDisplayed, Is.True);
        }

        [AfterScenario]
        public void TestCleanUp()
        {
            ahorcadoPage.Close();
        }
    }
}
