using FluentAssertions;
using MudBlazor;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UITesting.ResearchProjects.SeleniumTests
{
    public class EditResearchProjectInfo
    {
        IWebDriver driver = null!;

        [Fact]
        public void ResearchProjectNameChangeSuccess()
        {
            driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("admin@admin.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/proyectos/723-B9-343";
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
                    element.ElementAt(1).Click();
                    clicked = false;
                    System.Threading.Thread.Sleep(3500);
                    
                    var textField = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div/input"));
                    System.Threading.Thread.Sleep(3500);
                    textField.Clear();
                    System.Threading.Thread.Sleep(3000);
                    textField.SendKeys("Intervenciones en infancia temprana para reducir la desigualdad en las oportunidades educativas.");
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
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div[2]/h1")).Text, "Intervenciones en infancia temprana para reducir la desigualdad en las oportunidades educativas.");
        }

        [Fact]
        public void ResearchProjectNameChangeFailed()
        {
            driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Arrange 
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("admin@admin.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/proyectos/723-B9-343";
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
                    element.ElementAt(1).Click();
                    clicked = false;
                    System.Threading.Thread.Sleep(3500);
                    var textField = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div/input"));
                    if (cleared)
                    {
                        text = textField.GetAttribute("value");
                    }
                    System.Threading.Thread.Sleep(3500);
                    textField.Clear();
                    cleared = false;
                    System.Threading.Thread.Sleep(3000);
                    textField.SendKeys("Se dice que entre 600 y 1000 palabras es la logitud recomendada para los artículos que se publican habitualmente, " +
                        "y es una extención cómoda de leer para web. Si esamos escribiendo un artículo y vemos que este supera " +
                        "ampliamente las 1400 palabras, debemos plantearno si ampliarlo y separarlo en dos artículos que traten dos aspectos de un mismo tema.");
                    System.Threading.Thread.Sleep(3000);
                    element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(2).Click();
                    driver.Url = "http://10.1.4.119/proyectos/723-B9-343";
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    aux = true;
                }
            }
            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div[2]/h1")).Text, text);
        }

        [Fact]
        public void ResearchProjectDateChangeSuccess()
        {
            driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("admin@admin.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/proyectos/723-B9-343";
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

                    var textField = driver.FindElement(By.CssSelector("body>div.pageContentWrapper>div>div>div>div>div:nth-child(2)>div.mud-grid.mud-grid-spacing-xs-3.justify-center.d-flex.justify-center.flex-grow-1.gap-4>div:nth-child(2)>div>div>input"));
                    System.Threading.Thread.Sleep(3500);
                    textField.SendKeys("12122022");
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
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div[3]/div[1]/h6")).Text, "01 de enero del 2019 hasta 12 de diciembre del 2022");
        }

        [Fact]
        public void ResearchProjectNameCancel()
        {
            driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("admin@admin.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/proyectos/723-B9-343";
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
                    element.ElementAt(1).Click();
                    clicked = false;
                    System.Threading.Thread.Sleep(3500);
                    var textField = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div[2]/div[1]/div/div/input"));
                    if (cleared)
                    {
                        text = textField.GetAttribute("value");
                    }
                    System.Threading.Thread.Sleep(3500);
                    element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(1).Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    aux = true;
                }
            }
            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div[2]/h1")).Text, text);
        }
        [Fact]
        public void ResearchProjectDateChangeCancel()
        {
            driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("admin@admin.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/proyectos/723-B9-343";
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

                    var textField = driver.FindElement(By.CssSelector("body>div.pageContentWrapper>div>div>div>div>div:nth-child(2)>div.mud-grid.mud-grid-spacing-xs-3.justify-center.d-flex.justify-center.flex-grow-1.gap-4>div:nth-child(2)>div>div>input"));
                    System.Threading.Thread.Sleep(3500);
                    textField.SendKeys("12311969");
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
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div[3]/div[1]/h6")).Text, "01 de enero del 2019 hasta 12 de diciembre del 2022");
        }

        [Fact]
        public void ResearchProjectDateChangeFailed()
        {
            driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("admin@admin.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/proyectos/723-B9-343";
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

                    var textField = driver.FindElement(By.CssSelector("body>div.pageContentWrapper>div>div>div>div>div:nth-child(2)>div.mud-grid.mud-grid-spacing-xs-3.justify-center.d-flex.justify-center.flex-grow-1.gap-4>div:nth-child(2)>div>div>input"));
                    System.Threading.Thread.Sleep(3500);
                    textField.SendKeys("03012018");
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
            driver.Url = "http://10.1.4.119/proyectos/723-B9-343";
            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div[3]/div[1]/h6")).Text, "01 de enero del 2019 hasta 12 de diciembre del 2022");
        }


    }
}
