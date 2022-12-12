
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UITesting.Login
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
        public void EmailInvalidInputFormat()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            email.SendKeys("email");
            email.Submit();
            Assert.AreEqual(driver.FindElement(By.Id("Email-error")).Text, "El email ingresado no es válido");
            TearDown();
        }

        [Fact]
        public void EmailInvalidInputEmpty()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            email.SendKeys("");
            email.Submit();
            Assert.AreEqual(driver.FindElement(By.Id("Email-error")).Text, "Debe ingresar un correo");
            TearDown();
        }

        [Fact]
        public void PasswordInvalidInputEmpty()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("");
            email.Submit();
            Assert.AreEqual(driver.FindElement(By.Id("Contrasena-error")).Text, "Debe ingresar una contraseña");
            TearDown();
        }
        
        [Fact]
        public void ShowHidePasswordEye()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("ojo"));
            email.Click();
            email.Submit();
            driver.FindElement(By.XPath("//input[@type='text']"));
            email.Click();
            driver.FindElement(By.XPath("//input[@type='password']"));
            TearDown();
        }

        [Fact]
        public void LoginFailTest()
        {
            driver = new ChromeDriver();
            ///Arrange
            /// Pone la pantalla en full screen
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL de la aplicacion
            driver.Url = "https://localhost:7075/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("abc@fail.com");
            pass.SendKeys("Fail!12");
            email.Submit();
            Assert.AreEqual(driver.FindElement(By.XPath("//li")).Text, "Inicio de sesión no válido");
            TearDown();
        }

        [Fact]
        public void LoginSuccessfulTest()
        {
            driver = new ChromeDriver();
            ///Arrange
            /// Pone la pantalla en full screen
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL de la aplicacion
            driver.Url = "https://localhost:7075/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("abc@abc.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            TearDown();
        }

    }
}
