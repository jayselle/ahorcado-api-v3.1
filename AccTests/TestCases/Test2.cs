using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AccTests.TestCases
{
    public class Test2
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
                "t", "e", "s", "i", "n", "g"
            };
            letrasAIngresar.ForEach(x =>
            {
                txtLetra.SendKeys(x);
                var btnArriesgarLetra = driver.FindElement(By.Id("btnArriesgarLetra"));
                btnArriesgarLetra.Click();
            });

            wait.Until(x => x.FindElement(By.Id("winMessage")));
            bool isPresent = driver.FindElements(By.Id("winMessage")).Count > 0;

            // Asset
            Assert.IsTrue(isPresent);
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
            driver.Dispose();
            driver.Quit();
        }
    }
}
