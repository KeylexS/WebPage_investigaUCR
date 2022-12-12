using FluentAssertions;
using MudBlazor;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;
using SeleniumExtras.WaitHelpers;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UITesting.ResearchGroups.SeleniumTests
{
    public class GroupNameAndDescriptionTest
    {
        IWebDriver driver = null!;

        [Fact]
        public void ChangeNameValid() 
        {            
            driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("coordinator@coordinator.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/grupos/CRCUCRCITICXD";            
            bool aux = true;
            bool clicked = true;
            while (aux)
            {
                try
                {
                    if (clicked)
                    {
                        js.ExecuteScript("window.scrollBy(0,300)");
                    }
                    var element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(2).Click();
                    clicked = false;
                    System.Threading.Thread.Sleep(3500);
                    var textField = driver.FindElement(By.Id("NameField"));
                    System.Threading.Thread.Sleep(3500);
                    textField.Clear();
                    System.Threading.Thread.Sleep(3000);
                    textField.SendKeys("Ingeniería de Software Empírica.");
                    element = driver.FindElements(By.Id("ToolButton"));      
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(3).Click();
                    break;
                }
                catch(StaleElementReferenceException)
                {
                    aux = true;
                }
            }
            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.Id("Name")).Text, "Ingeniería de Software Empírica.");
        }

        [Fact]
        public void ChangeDescriptionValid()
        {
            driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("coordinator@coordinator.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/grupos/CRCUCRCITICXD";
            bool aux = true;
            bool clicked = true;
            while (aux)
            {
                try
                {
                    if (clicked)
                    {
                        js.ExecuteScript("window.scrollBy(0,400)");
                    }
                    var element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(3).Click();
                    clicked = false;
                    System.Threading.Thread.Sleep(3500);
                    var textField = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[4]/div[1]/div/div/textarea"));
                    System.Threading.Thread.Sleep(3500);
                    textField.Clear();
                    System.Threading.Thread.Sleep(3000);
                    textField.SendKeys("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pharetra nisi et elit condimentu.");
                    element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(4).Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    aux = true;
                }
            }
            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[4]/p")).Text, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pharetra nisi et elit condimentu.");
        }
        [Fact]
        public void ChangeDescriptionCancel()
        {
            driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("coordinator@coordinator.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/grupos/CRCUCRCITICXD";
            bool aux = true;
            bool clicked = true;
            while (aux)
            {
                try
                {
                    if (clicked)
                    {
                        js.ExecuteScript("window.scrollBy(0,400)");
                    }
                    var element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(3).Click();
                    clicked = false;
                    System.Threading.Thread.Sleep(3500);
                    var textField = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[4]/div[1]/div/div/textarea"));
                    System.Threading.Thread.Sleep(3500);
                    textField.Clear();
                    System.Threading.Thread.Sleep(3000);
                    textField.SendKeys("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pharetra nisi et elit condimentu.");
                    element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(3).Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    aux = true;
                }
            }
            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[4]/p")).Text, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pharetra nisi et elit condimentu");
        }
        [Fact]
        public void ChangeDescriptionVoidDesc()
        {
            driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("coordinator@coordinator.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/grupos/CRCUCRCITICXD";
            bool aux = true;
            bool clicked = true;
            while (aux)
            {
                try
                {
                    if (clicked)
                    {
                        js.ExecuteScript("window.scrollBy(0,400)");
                    }
                    var element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(3).Click();
                    clicked = false;
                    System.Threading.Thread.Sleep(3500);
                    var textField = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[4]/div[1]/div/div/textarea"));
                    System.Threading.Thread.Sleep(3500);
                    textField.Clear();
                    System.Threading.Thread.Sleep(3000);
                    textField.SendKeys("");
                    element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(4).Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    aux = true;
                }
            }
            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[4]/p")).Text, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pharetra nisi et elit condimentu");
        }

        [Fact]
        public void ChangeNameInvalid()
        {
            driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("coordinator@coordinator.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/grupos/CRCUCRCITICXD";
            bool aux = true;
            bool clicked = true;
            bool cleared = true;
            string text = "";
            while (aux)
            {
                try
                {
                    if (clicked)
                    {
                        js.ExecuteScript("window.scrollBy(0,300)");
                    }
                    var element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(2).Click();
                    clicked = false;
                    System.Threading.Thread.Sleep(3500);
                    var textField = driver.FindElement(By.Id("NameField"));
                    if (cleared) 
                    {
                        text = textField.GetAttribute("value");
                    }                    
                    System.Threading.Thread.Sleep(3500);
                    textField.Clear();
                    cleared = false;
                    System.Threading.Thread.Sleep(3000);
                    element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(3).Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    aux = true;
                }
            }
            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.Id("Name")).Text, text);
        }

        [Fact]
        public void ChangeNameCancel()
        {
            driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("coordinator@coordinator.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/grupos/CRCUCRCITICXD";
            bool aux = true;
            bool clicked = true;
            bool cleared = true;
            string text = "";
            while (aux)
            {
                try
                {
                    if (clicked)
                    {
                        js.ExecuteScript("window.scrollBy(0,300)");
                    }
                    var element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(2).Click();
                    clicked = false;
                    System.Threading.Thread.Sleep(3500);
                    var textField = driver.FindElement(By.Id("NameField"));
                    if (cleared)
                    {
                        text = textField.GetAttribute("value");
                    }
                    System.Threading.Thread.Sleep(3500);
                    element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(2).Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    aux = true;
                }
            }
            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.Id("Name")).Text, text);
        }
    }
}
