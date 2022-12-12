
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UiTesting.Selenium.Login
{

    public class LoginTestSelenium
    {
        IWebDriver driver;

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
                driver.Quit();
        }

        [Fact]
        public void PruebaIngresoChrome()
        {
            ///Arrange
            /// Crea el driver de Chrome
            driver = new ChromeDriver();
            PruebaIngreso();
        }

        [Fact]
        public void SuccesfulLoginTest()
        {
            driver = new ChromeDriver();
            ///Arrange
            /// Pone la pantalla en full screen
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL de la aplicacion
            driver.Url = "https://localhost:7075/";
            var loginButton = driver.FindElement(By.Id("LoginButton"));
            loginButton.Click(); 
        }

        private void PruebaIngreso()
        {
            ///Arrange
            /// Pone la pantalla en full screen
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL de la aplicacion
            driver.Url = "https://localhost:7075/";
            ///Assert
            Assert.AreEqual(driver.FindElement(By.XPath("//h1")).Text, "Grupos de Investigación");
        }
    }
}
