using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AccTests.TestCases
{
    public class Test1
    {
        IWebDriver driver;

        [SetUp]
        public void InitializeTest()
        {
            driver = new FirefoxDriver();
        }

        [Test]
        public void RunTest()
        {
            // Arrange
            driver.Url = "https://ahorcado-web-v3-1.herokuapp.com";
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
            wait.Until(x => x.FindElement(By.Id("btnTest")));

            // Act
            var btnTest = driver.FindElement(By.Id("btnTest"));
            btnTest.Click();

            var txtLetra = driver.FindElement(By.Id("txtLetra"));
            var letrasAIngresar = new List<string>
            {
                "a", "b", "c", "d", "f", "h"
            };
            letrasAIngresar.ForEach(x =>
            {
                txtLetra.SendKeys(x);
                var btnArriesgarLetra = driver.FindElement(By.Id("btnArriesgarLetra"));
                btnArriesgarLetra.Click();
            });

            bool isPresent = driver.FindElements(By.Id("gameOverMessage")).Count > 0;

            var txtIntentos = driver.FindElement(By.Id("txtIntentos"));
            var intentos = Convert.ToInt32(txtIntentos.GetAttribute("value"));

            // Asset
            Assert.IsTrue(isPresent);
            Assert.AreEqual(0, intentos);
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}
