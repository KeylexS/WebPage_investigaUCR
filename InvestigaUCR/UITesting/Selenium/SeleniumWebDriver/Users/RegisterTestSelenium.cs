using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UITesting.Selenium.SeleniumWebDriver.Users
{
    [TestClass]
    public class RegisterTestSelenium
    {
        IWebDriver? driver;

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
                driver.Quit();
        }

        [Fact]
        public void TestEmptyEmail()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/Identity/Account/Register/";

            //Invalid email
            var email = driver.FindElement(By.Id("Email"));
            email.SendKeys("");

            email.Submit();
            //Assert
            Assert.AreEqual(driver.FindElement(By.Id("Email-error")).Text, "Debe escribir un correo");

            TearDown();
        }

        [Fact]
        public void TestInvalidEmail()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/Identity/Account/Register/";

            //Invalid email
            var email = driver.FindElement(By.Id("Email"));
            email.SendKeys("invalidEmail");

            email.Submit();
            //Assert
            Assert.AreEqual(driver.FindElement(By.Id("Email-error")).Text, "El correo no es válido");

            TearDown();
        }

        [Fact]
        public void TestPasswordFeedback()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/Identity/Account/Register/";

            //Valid email
            var email = driver.FindElement(By.Id("Email"));
            email.SendKeys("emailTest@test.com");

            //Invalid password (requirements)
            var password = driver.FindElement(By.Id("Contrasena"));
            password.SendKeys("abc");

            //Valid confirm password match
            var confirmPassword = driver.FindElement(By.Id("Confirm-contrasena"));
            confirmPassword.SendKeys("abc");

            email.Submit();

            //Assert
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id=\"account\"]/div[1]/ul")).Text, "- La contraseña deben contener al menos 6 caracteres.\r\n" +
                                                                                                 "- La contraseña debe contener al menos un caracter especial.\r\n" +
                                                                                                 "- La contraseña debe contener al menos un numero.\r\n" +
                                                                                                 "- La contraseña debe contener al menos una mayúscula.");

            TearDown();
        }

        [Fact]
        public void TestInvalidConfirmPassword()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/Identity/Account/Register/";

            //Valid email
            var email = driver.FindElement(By.Id("Email"));
            email.SendKeys("emailprueba@prueba.com");

            //Valid password
            var password = driver.FindElement(By.Id("Contrasena"));
            password.SendKeys("Abc!12");

            //Invalid confirm password match with first password.
            var confirmPassword = driver.FindElement(By.Id("Confirm-contrasena"));
            confirmPassword.SendKeys("Abc!123");
            confirmPassword.Submit();

            //Assert
            Assert.AreEqual(driver.FindElement(By.Id("Confirm-contrasena-error")).Text, "Las contraseñas no coinciden");

            TearDown();
        }

        [Fact]
        public void TestTryRegisterAnExistUser()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/Identity/Account/Register/";

            //Valid email but already exists
            var email = driver.FindElement(By.Id("Email"));
            email.SendKeys("admin@admin.com");

            //Valid password
            var password = driver.FindElement(By.Id("Contrasena"));
            password.SendKeys("Abc!12");

            //Valid confirm password match
            var confirmPassword = driver.FindElement(By.Id("Confirm-contrasena"));
            confirmPassword.SendKeys("Abc!12");

            email.Submit();
            //Assert
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id=\"account\"]/div[1]/ul")).Text, "- El usuario 'admin@admin.com' ya existe.");

            TearDown();
        }


        [Fact]
        public void TestRegisterAnUser()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/Identity/Account/Register/";

            //Valid email but already exists
            var email = driver.FindElement(By.Id("Email"));
            email.SendKeys("pruebaUItest@pruebaUItest.com");

            //Valid password
            var password = driver.FindElement(By.Id("Contrasena"));
            password.SendKeys("Abc!12");

            //Valid confirm password match
            var confirmPassword = driver.FindElement(By.Id("Confirm-contrasena"));
            confirmPassword.SendKeys("Abc!12");

            email.Submit();
            
            //Assert
            Assert.AreEqual(driver.Url, "https://localhost:7075/Identity/Account/RegisterConfirmation?email=pruebaUItest@pruebaUItest.com&returnUrl=%2F");

            TearDown();
        }

    }
}
