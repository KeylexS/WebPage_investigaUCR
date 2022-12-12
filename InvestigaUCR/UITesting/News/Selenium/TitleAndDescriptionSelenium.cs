using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UITesting.News.TitleAndDescriptionSelenium
{
    [TestClass]
    public class TitleAndDescriptionSelenium
    {
        IWebDriver driver;

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
                driver.Quit();
        }

        [Fact]
        public void ChangeTitleValid()
        {
            driver = new ChromeDriver();

            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("coordinator@coordinator.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/noticias/CITIC-1";
            bool aux = true;
            while (aux)
            {
                try
                {
                    System.Threading.Thread.Sleep(3500);
                    var element = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div/button"));
                    System.Threading.Thread.Sleep(3500);
                    element.Click();
                    System.Threading.Thread.Sleep(3500);
                    var textField = driver.FindElement(By.Id("TitleField"));
                    System.Threading.Thread.Sleep(3500);
                    textField.Clear();
                    System.Threading.Thread.Sleep(3500);
                    textField.SendKeys("CITIC RECIBIÓ LA VISITA DEL PROFESOR JOÃO VIDAL CARVALHO DEL POLITÉCNICO DE PORTO, PORTUGAL");
                    var confirmButtons = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[3]/button"));
                    System.Threading.Thread.Sleep(3500);
                    confirmButtons.Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    aux = true;
                }
            }

            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.Id("Title")).Text, "CITIC RECIBIÓ LA VISITA DEL PROFESOR JOÃO VIDAL CARVALHO DEL POLITÉCNICO DE PORTO, PORTUGAL");
        }

        [Fact]
        public void ChangeTitleCancel()
        {
            driver = new ChromeDriver();

            // Arrange
            driver.Manage().Window.Maximize();
            driver.Url = "http://10.1.4.119/Identity/Account/Login/";
            var email = driver.FindElement(By.Id("Email"));
            var pass = driver.FindElement(By.Id("Contrasena"));
            email.SendKeys("coordinator@coordinator.com");
            pass.SendKeys("Abc!12");
            email.Submit();
            driver.Url = "http://10.1.4.119/noticias/CITIC-1";
            bool aux = true;
            bool cleared = true;
            string text = "";
            while (aux)
            {
                try
                {
                    System.Threading.Thread.Sleep(3500);
                    var element = driver.FindElements(By.Id("ToolButton"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(1).Click();
                    System.Threading.Thread.Sleep(3500);
                    var textField = driver.FindElement(By.Id("TitleField"));
                    if (cleared)
                    {
                        text = textField.GetAttribute("value");
                    }
                    System.Threading.Thread.Sleep(3500);
                    var cancelbuttom = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/button"));
                    System.Threading.Thread.Sleep(3500);
                    cancelbuttom.Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    aux = true;
                }
            }
            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.Id("Title")).Text, text);
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
            driver.Url = "http://10.1.4.119/noticias/CITIC-1";
            bool aux = true;
            while (aux)
            {
                try
                {
                    System.Threading.Thread.Sleep(3500);
                    var element = driver.FindElements(By.XPath("/html/body/div[1]/div/div/div/div[3]/div/button"));
                    System.Threading.Thread.Sleep(3500);
                    element.ElementAt(0).Click();
                    System.Threading.Thread.Sleep(3500);
                    var textField = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div[1]/div/div/textarea"));
                    System.Threading.Thread.Sleep(3500);
                    textField.Clear();
                    System.Threading.Thread.Sleep(3500);
                    textField.SendKeys("El Profesor Carvalho es miembro del Centro de Investigación CEOS.PP, un centro de investigación multidisciplinar en el área de las ciencias sociales, con publicaciones y proyectos en diversos campos, concretamente en Sistemas de Información, Gestión, Economía y Comunicación, siempre con un enfoque muy especial en los servicios digitales.\n\nCEOS.PP lleva a cabo investigaciones de alta calidad en los campos del Emprendimiento, la Innovación, el Marketing, las Comunicaciones, los Recursos Humanos, la Economía Social, los Sistemas de Información y Tecnología, así como en el Análisis Corporativo, Social y Educativo.");
                    var confirmButtons = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div[3]/button"));
                    System.Threading.Thread.Sleep(3500);
                    confirmButtons.Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    aux = true;
                }
            }

            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/p")).Text, "El Profesor Carvalho es miembro del Centro de Investigación CEOS.PP, un centro de investigación multidisciplinar en el área de las ciencias sociales, con publicaciones y proyectos en diversos campos, concretamente en Sistemas de Información, Gestión, Economía y Comunicación, siempre con un enfoque muy especial en los servicios digitales. CEOS.PP lleva a cabo investigaciones de alta calidad en los campos del Emprendimiento, la Innovación, el Marketing, las Comunicaciones, los Recursos Humanos, la Economía Social, los Sistemas de Información y Tecnología, así como en el Análisis Corporativo, Social y Educativo.");
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
            driver.Url = "http://10.1.4.119/noticias/CITIC-1";
            bool aux = true;
            while (aux)
            {
                try
                {
                    System.Threading.Thread.Sleep(4500);
                    var element = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div/button"));
                    System.Threading.Thread.Sleep(3500);
                    element.Click();
                    System.Threading.Thread.Sleep(3500);
                    var textField = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div[1]/div/div/textarea"));
                    System.Threading.Thread.Sleep(3500);
                    textField.Clear();
                    System.Threading.Thread.Sleep(3500);
                    textField.SendKeys("El Profesor Carvalho es miembro del Centro de Investigación CEOS.PP, un centro de investigación multidisciplinar en el área de las ciencias sociales, con publicaciones y proyectos en diversos campos, concretamente en Sistemas de Información, Gestión, Economía y Comunicación, siempre con un enfoque muy especial en los servicios digitales.\n\nCEOS.PP lleva a cabo investigaciones de alta calidad en los campos del Emprendimiento, la Innovación, el Marketing, las Comunicaciones, los Recursos Humanos, la Economía Social, los Sistemas de Información y Tecnología, así como en el Análisis Corporativo, Social y Educativo.");
                    var confirmButtons = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div[2]/button"));
                    System.Threading.Thread.Sleep(3500);
                    confirmButtons.Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    aux = true;
                }
            }

            System.Threading.Thread.Sleep(3500);
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/p")).Text, "El Profesor Carvalho es miembro del Centro de Investigación CEOS.PP, un centro de investigación multidisciplinar en el área de las ciencias sociales, con publicaciones y proyectos en diversos campos, concretamente en Sistemas de Información, Gestión, Economía y Comunicación, siempre con un enfoque muy especial en los servicios digitales. CEOS.PP lleva a cabo investigaciones de alta calidad en los campos del Emprendimiento, la Innovación, el Marketing, las Comunicaciones, los Recursos Humanos, la Economía Social, los Sistemas de Información y Tecnología, así como en el Análisis Corporativo, Social y Educativo.");
        }

    }
}

