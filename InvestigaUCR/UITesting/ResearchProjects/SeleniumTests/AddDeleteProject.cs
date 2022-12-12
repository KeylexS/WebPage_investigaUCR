using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SeleniumTesting
{
    [TestClass]
    public class AddDeleteProject
    {
        IWebDriver driver;
        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
                driver.Quit();
        }
        [TestMethod]
        public void PruebaIngresoChrome()
        {
            ///Arrange
            /// Crea el driver de Chrome
            driver = new ChromeDriver();
            PruebaIngreso();
        }

        private void PruebaIngreso()
        {
            ///Arrange
            /// Pone la pantalla en full screen
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL de la aplicacion
            driver.Url = "http://10.1.4.119";
            ///Assert
            Assert.AreEqual(driver.FindElement(By.XPath("//h1")).Text, "Grupos de Investigación");
        }

        [TestMethod]
        public void testAddProject()
        {
            ///Arrange
            /// Pone la pantalla en full screen
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL de la aplicacion
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("admin@admin.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/proyectos";
            System.Threading.Thread.Sleep(3500);
            ///Assert
            var element = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/h1/div[2]/button"));
            element.ElementAt(0).Click();
            System.Threading.Thread.Sleep(3500);
            var id = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[2]/div[1]/div/input"));
            id.SendKeys("123-12-123");
            System.Threading.Thread.Sleep(1000);
            var name = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div/div/textarea"));
            name.SendKeys("Sistema para el hallazgo de hipercubos con el análisis multivariado de datos");
            var StarDate = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[4]/div[1]/div/div/input"));
            StarDate.SendKeys("11/11/2022");
            var EndDate = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[4]/div[2]/div/div/input"));
            EndDate.SendKeys("11/11/2023");
            var MainResearcher = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[6]/div/div/div[1]/input"));
            MainResearcher.Click();
            MainResearcher.SendKeys("Adrian");
            System.Threading.Thread.Sleep(500);
            MainResearcher.SendKeys(Keys.Enter);
            MainResearcher.Click();
            System.Threading.Thread.Sleep(1000);
            var GroupResearch = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[8]/div/div/div[1]/input"));
            GroupResearch.Click();
            GroupResearch.SendKeys("Computación");
            System.Threading.Thread.Sleep(500);
            GroupResearch.SendKeys(Keys.Enter);
            var crear = driver.FindElements(By.XPath("/html/body/div[1]/div[2]/div[2]/div[5]/div/button[2]"));
            crear.ElementAt(0).Click();
            System.Threading.Thread.Sleep(3500);
            var cancelar = driver.FindElements(By.XPath("/html/body/div[1]/div[2]/div[2]/div[5]/div/button[1]"));
            cancelar.ElementAt(0).Click();
            System.Threading.Thread.Sleep(3500);
            var list = driver.FindElements(By.XPath("//*[contains(text(),'" + "321-21-321" + "')]"));
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod]
        public void testDeleteProject()
        {
            ///Arrange
            /// Pone la pantalla en full screen
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL de la aplicacion
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("admin@admin.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/proyectos/321-21-321";
            System.Threading.Thread.Sleep(1000);
            ///Assert
            var element = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div[1]/div[3]/div[1]/button"));
            element.ElementAt(0).Click();
            System.Threading.Thread.Sleep(1000);
            var eliminar = driver.FindElements(By.XPath("/html/body/div[1]/div[2]/div[2]/div[5]/button[2]"));
            eliminar.ElementAt(0).Click();
            System.Threading.Thread.Sleep(3500);
            var list = driver.FindElements(By.XPath("//*[contains(text(),'" + "321-21-321" + "')]"));
            Assert.IsFalse(list.Count() > 0);
        }
    }
}