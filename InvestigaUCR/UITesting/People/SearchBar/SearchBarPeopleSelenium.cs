using LanguageExt.Pretty;
using LanguageExt.TypeClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.IO;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UITesting.People.SearchBar
{
    public class SearchBarPeopleSelenium
    {
        IWebDriver driver;

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
                driver.Quit();
        }

        [Fact]
        public void SearchBarPeopleFindPersonbyEmail()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas";
            var searchBar = driver.FindElement(By.Id("SearchBarPeople"));
            searchBar.SendKeys("adrian.lara@ucr.ac.cr");
            searchBar.Submit();
            Assert.AreEqual(driver.FindElement(By.Id("adrian.lara@ucr.ac.cr")).Text, "Dr. Adrián Lara");
            TearDown();
        }

        [Fact]
        public void SearchBarPeopleFindPersonbyHighestDegree()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas";
            try
            {
                var searchBar = driver.FindElement(By.Id("SearchBarPeople"));
                searchBar.SendKeys("Bach.");
                searchBar.Submit();
                Assert.AreEqual(driver.FindElement(By.Id("SearchBarPeople")).Text, "Bach.");
            }
            catch (OpenQA.Selenium.StaleElementReferenceException ex)
            {
                var searchBar = driver.FindElement(By.Id("SearchBarPeople"));
                searchBar.SendKeys("Bach.");
                searchBar.Submit();
                Assert.AreEqual(driver.FindElement(By.Id("SearchBarPeople")).Text, "Bach.");
            }
            TearDown();
        }
        [Fact]
        public void SearchBarPeopleFindPersonbyUniversity()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas";
            try
            {
                var searchBar = driver.FindElement(By.Id("SearchBarPeople"));
                searchBar.SendKeys("Universidad de Costa Rica");
                searchBar.Submit();
                Assert.AreEqual(driver.FindElement(By.Id("SearchBarPeople")).Text, "Universidad de Costa Rica");
            }
            catch (OpenQA.Selenium.StaleElementReferenceException ex)
            {
                var searchBar = driver.FindElement(By.Id("SearchBarPeople"));
                searchBar.SendKeys("Universidad de Costa Rica");
                searchBar.Submit();
                Assert.AreEqual(driver.FindElement(By.Id("SearchBarPeople")).Text, "Universidad de Costa Rica");
            }
            TearDown();
        }
        [Fact]
        public void SearchBarPeopleFindPersonbyName()
        {
            driver = new ChromeDriver();
            ///Arrange
            driver.Manage().Window.Maximize();
            ///Act
            driver.Url = "https://localhost:7075/personas";
            try
            {
                var searchBar = driver.FindElement(By.Id("SearchBarPeople"));
                searchBar.SendKeys("Sivana");
                searchBar.Submit();
                Assert.AreEqual(driver.FindElement(By.Id("SearchBarPeople")).Text, "Sivana");
            }
            catch (OpenQA.Selenium.StaleElementReferenceException ex)
            {
                var searchBar = driver.FindElement(By.Id("SearchBarPeople"));
                searchBar.SendKeys("Sivana");
                searchBar.Submit();
                Assert.AreEqual(driver.FindElement(By.Id("SearchBarPeople")).Text, "Sivana");
            }

            TearDown();
        }
    }
}
