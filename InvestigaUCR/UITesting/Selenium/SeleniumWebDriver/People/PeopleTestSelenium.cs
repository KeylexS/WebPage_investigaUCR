using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class PeopleTestSelenium
    {
        IWebDriver? driver;

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
                driver.Quit();
        }

        [Fact]
        public void TestPersonHasName()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas/lyon.villalobos@gmail.com";

            //Assert
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/h2[1]")).Text ,
                            "Lic. Leonardo Villalobos Arias");

            TearDown();
        }

        [Fact]
        public void TestPersonHasUniversity()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas/lyon.villalobos@gmail.com";

            //Assert
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/h3")).Text,
                            "Universidad de Costa Rica");

            TearDown();
        }

        [Fact]
        public void TestBreadcrumbCorrect()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas/lyon.villalobos@gmail.com";

            //Assert
            Assert.AreEqual(driver.FindElement(By.LinkText("Lyon.villalobos@gmail.com")).Text,
                            "Lyon.villalobos@gmail.com");

            TearDown();
        }

        [Fact]
        public void TestBreadcrumbIncorrect()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas/lyon.villalobos@gmail.com";

            //Assert
            Assert.AreNotEqual(driver.FindElement(By.LinkText("Lyon.villalobos@gmail.com")).Text,
                            "lyon.villalobos@gmail.com");

            TearDown();
        }

        [Fact]
        public void TestPersonDisplayProyects()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas/lyon.villalobos@gmail.com";

            //Assert
            Assert.AreEqual(driver.FindElement(By.Id("projects")).Text,"Proyectos");

            TearDown();
        }

        [Fact]
        public void TestPersonDisplayPublications()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas/lyon.villalobos@gmail.com";

            //Assert
            Assert.AreEqual(driver.FindElement(By.Id("publications")).Text, "Publicaciones");

            TearDown();
        }

        [Fact]
        public void TestPersonDisplayResearchGGroups()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas/lyon.villalobos@gmail.com";

            //Assert
            Assert.AreEqual(driver.FindElement(By.Id("researchGroups")).Text, "Grupos de Investigación");

            TearDown();
        }

        [Fact]
        public void TestPersonDisplayTheses()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas/lyon.villalobos@gmail.com";

            //Assert
            Assert.AreEqual(driver.FindElement(By.Id("theses")).Text, "Tesis");

            TearDown();
        }
    }
}
