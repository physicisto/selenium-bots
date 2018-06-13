using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using System;
using System.Text.RegularExpressions;

namespace AutoTest
{
    [TestFixture]
    public class Test
    {
        public static string igWorkDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); // рабочий каталог, относительно исполняемого файла (в нашем случае относительно DLL)
        public static IWebDriver driver;

        [OneTimeSetUp] // вызывается перед началом запуска всех тестов
        public void OneTimeSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--ignore-ssl-errors");
            driver = new ChromeDriver(igWorkDir, options);
            driver.Manage().Window.Minimize();
        }

        [OneTimeTearDown] //вызывается после завершения всех тестов
        public void OneTimeTearDown()
        {
            //driver.Quit();
        }

        [SetUp] // вызывается перед каждым тестом
        public void SetUp()
        {
            // ТУТ КОД
        }

        [TearDown] // вызывается после каждого теста
        public void TearDown()
        {
        }

        [Test]
        public void TEST_1()
        {
            driver.Navigate().GoToUrl("http://teeda.mgates.ru/game/");
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.Name("login")).SendKeys("ГВетер");
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).SendKeys("ГВетер");
            System.Threading.Thread.Sleep(509);
            driver.FindElement(By.Name("enter")).Click();
            driver.Navigate().GoToUrl("http://teeda.mgates.ru/game/");
            System.Threading.Thread.Sleep(1020);
            driver.FindElement(By.ClassName("butt")).Click();
            System.Threading.Thread.Sleep(10020);
            while (true)
            {
                driver.FindElement(By.LinkText("Приключения")).Click();
                System.Threading.Thread.Sleep(434);
                driver.FindElement(By.LinkText("Охота")).Click();
                System.Threading.Thread.Sleep(612);
                driver.FindElement(By.LinkText("сфера вампиризма")).Click();
                System.Threading.Thread.Sleep(540);
                driver.FindElement(By.LinkText("покинуть бой")).Click();
                driver.FindElement(By.ClassName("but2")).Click();
                System.Threading.Thread.Sleep(602000);
            }
        }
        
    }
}
