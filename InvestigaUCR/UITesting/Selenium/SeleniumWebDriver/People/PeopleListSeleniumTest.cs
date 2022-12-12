using LanguageExt.Pretty;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UITesting.Selenium.SeleniumWebDriver.People
{
    public class PeopleListSeleniumTest
    {
        IWebDriver driver;

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
                driver.Quit();
        }

        [Fact]
        public void PeopleListSearchName()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(7);
            Assert.AreEqual(driver.FindElement(By.LinkText("Dr. Christian Quesada")).Text,
                            "Dr. Christian Quesada");
            TearDown();
        }
        [Fact]
        public void PeopleListSearchEmail()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(7);
            Assert.AreEqual(driver.FindElement(By.LinkText("Dr. Christian Quesada")).Text,
                            "Dr. Christian Quesada");

            TearDown();
        }
        [Fact]
        public void PeopleListSearchHighestDegree()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(7);
            Assert.AreEqual(driver.FindElement(By.LinkText("Dr. Christian Quesada")).Text,
                            "Dr. Christian Quesada");

            TearDown();
        }
        [Fact]
        public void PeopleListSearchUniversity()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(7);
            Assert.AreEqual(driver.FindElement(By.LinkText("Dr. Christian Quesada")).Text,
                            "Dr. Christian Quesada");

            TearDown();
        }
    }
}