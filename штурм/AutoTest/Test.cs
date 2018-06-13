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

        public static void Shvatka(string s)
        {
            while (true)
            {
                if (IsElementCon(s))
                    driver.FindElement(By.PartialLinkText("бить")).Click();
                if (IsElementCon(s))
                    driver.FindElement(By.PartialLinkText("сфера атаки")).Click();
                if (IsElementCon(s))
                {
                    driver.FindElement(By.PartialLinkText("сфера вампиризма")).Click();
                    System.Threading.Thread.Sleep(6000);
                }
                else
                    break;
            }
            return;
        }
        public static void Shvatka(string s,int n)
        {
            while (true)
            {
                if (IsElementCon(s))
                    driver.FindElement(By.PartialLinkText("бить")).Click();
                if (IsElementCon(s))
                    driver.FindElement(By.PartialLinkText("сфера атаки")).Click();
                if (IsElementCon(s))
                {
                    driver.FindElement(By.PartialLinkText("сфера вампиризма")).Click();
                    System.Threading.Thread.Sleep(6000);
                }
                else
                    break;
            }
            return;
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
            driver.FindElement(By.Name("login")).SendKeys("Гиви18");
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).SendKeys("Гиви18");
            driver.FindElement(By.Name("enter")).Click();
            driver.Navigate().GoToUrl("http://teeda.mgates.ru/game/");
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[2]/div[2]/div[4]/div[1]/table/tbody/tr[2]/td/p/a/input")).Click();
            //driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[2]/div[2]/div[4]/div[2]/table/tbody/tr[2]/td/p/a/input")).Click();
            //driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[2]/div[2]/div[4]/div[3]/table/tbody/tr[2]/td/p/a/input")).Click();

            //ПОХОД


            driver.FindElement(By.PartialLinkText("поход")).Click();
            driver.FindElement(By.PartialLinkText("атаковать")).Click();
            Shvatka("Бой завершен");



            //System.Threading.Thread.Sleep(15000);
            //while (true)
            //{
            //    driver.FindElement(By.PartialLinkText("Приключения")).Click();
            //    driver.FindElement(By.PartialLinkText("Штурм")).Click();
            //    Shvatka("воскреснуть", 1);
            //    driver.FindElement(By.PartialLinkText("воскреснуть")).Click();
            //    driver.FindElement(By.PartialLinkText("главная")).Click();
            //    System.Threading.Thread.Sleep(25000);
            //    driver.Navigate().Refresh();
            //}
        }

    }
}
