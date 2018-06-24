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

        public static bool IsElementCon(string s)
        {
            try
            {

                IWebElement sel = driver.FindElement(By.XPath(@"//*[contains(text(), '" + s + "')]"));

                return false;
            }
            catch (NoSuchElementException) { return true; } // если элемент вообще не найден
        }
        public static string igWorkDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); // рабочий каталог, относительно исполняемого файла (в нашем случае относительно DLL)
        public static IWebDriver driver;

        [OneTimeSetUp] // вызывается перед началом запуска всех тестов
        public void OneTimeSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--ignore-ssl-errors");
            driver = new ChromeDriver(igWorkDir, options);
            //driver.Manage().Window.Minimize();
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
            driver.FindElement(By.Name("login")).SendKeys("Чапаев22");
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).SendKeys("Чапаев22");
            driver.FindElement(By.Name("enter")).Click();
            driver.Navigate().GoToUrl("http://teeda.mgates.ru/game/");
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[2]/div[2]/div[4]/div[1]/table/tbody/tr[2]/td/p/a/input")).Click();
            //driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[2]/div[2]/div[4]/div[2]/table/tbody/tr[2]/td/p/a/input")).Click();
            //driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[2]/div[2]/div[4]/div[3]/table/tbody/tr[2]/td/p/a/input")).Click();

            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.PartialLinkText("Приключения")).Click();
            driver.FindElement(By.PartialLinkText("Окрестности")).Click();
            driver.FindElement(By.PartialLinkText("Полис Пирия - болота")).Click();
            while (true)
            {
                driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[4]/div[2]/table/tbody/tr/td[3]/div/div[2]/a")).Click();

                driver.FindElement(By.PartialLinkText("сфера молний")).Click();
                driver.FindElement(By.PartialLinkText("покинуть")).Click();
                //while (true)
                //{
                //    if (!IsElementCon("Бой завершен"))
                //    {
                //        driver.FindElement(By.PartialLinkText("покинуть")).Click();
                //        break;
                //    }
                //    else
                //    {
                //        System.Threading.Thread.Sleep(5000);
                //        driver.Navigate().Refresh();
                //        if (!IsElementCon("прекратил"))
                //        {
                //            driver.FindElement(By.PartialLinkText("сфера атаки")).Click();
                //        }
                //    }
                //}
                //System.Threading.Thread.Sleep(35000);
                //driver.Navigate().Refresh();
            }
        }
        
    }
}
