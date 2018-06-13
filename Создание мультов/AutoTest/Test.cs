using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

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
            //авторизация
            driver.Navigate().GoToUrl("http://teeda.mgates.ru/game/");
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.Name("login")).SendKeys("Чапаев24");
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).SendKeys("Чапаев24");
            driver.FindElement(By.ClassName("sbm")).Click();
            driver.Navigate().GoToUrl("http://teeda.mgates.ru/game/");
            driver.FindElement(By.LinkText("Создать героя")).Click();

            //задаём имя герою
            driver.FindElement(By.Id("Login")).SendKeys("Пифия");

            //расу
            IWebElement selectElem1 = driver.FindElement(By.Id("Race"));
            SelectElement select1 = new SelectElement(selectElem1);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options1 = select1.Options;
            select1.SelectByText("Атланты");

            //класс
            IWebElement selectElem2 = driver.FindElement(By.Id("Class"));
            SelectElement select2 = new SelectElement(selectElem2);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options2 = select2.Options;
            select2.SelectByText("маг");

            //пол
            IWebElement selectElem3 = driver.FindElement(By.Id("Sex"));
            SelectElement select3 = new SelectElement(selectElem3);
            System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options3 = select3.Options;
            select3.SelectByText("Женский");


            //создаем героя
            driver.FindElement(By.ClassName("butt")).Click();

            //продолжить
            driver.FindElement(By.ClassName("butt")).Click();

            //взять кинжал
            driver.FindElement(By.ClassName("butt")).Click();

            //продолжить 
            driver.FindElement(By.ClassName("butt")).Click();

            //сразиться
            driver.FindElement(By.ClassName("butt")).Click();

            driver.FindElement(By.PartialLinkText("бить")).Click();
            driver.FindElement(By.PartialLinkText("сфера атаки")).Click();
            driver.FindElement(By.PartialLinkText("покинуть бой")).Click();

            //продолжить
            driver.FindElement(By.ClassName("butt")).Click();

            //завершить
            driver.FindElement(By.ClassName("butt")).Click();

            //приступим
            driver.FindElement(By.ClassName("butt")).Click();

            driver.FindElement(By.PartialLinkText("Болотные дорожки")).Click();
            driver.FindElement(By.PartialLinkText("взять задание")).Click();
            driver.FindElement(By.PartialLinkText("Приключения")).Click();
            driver.FindElement(By.PartialLinkText("Окрестности")).Click();
            driver.FindElement(By.PartialLinkText("Полис Пирия - болота")).Click();

            //атакуем лягушку
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[4]/div[1]/table/tbody/tr/td[3]/div/div[2]/a")).Click();
            driver.FindElement(By.PartialLinkText("бить")).Click();
            driver.FindElement(By.PartialLinkText("сфера атаки")).Click();
            System.Threading.Thread.Sleep(6300);
            driver.FindElement(By.PartialLinkText("бить")).Click();
            driver.FindElement(By.PartialLinkText("сфера атаки")).Click();
            System.Threading.Thread.Sleep(6300);
            driver.FindElement(By.PartialLinkText("бить")).Click();
            driver.FindElement(By.PartialLinkText("покинуть")).Click();

            //в таверну
            driver.FindElement(By.PartialLinkText("главная")).Click();
            driver.FindElement(By.PartialLinkText("Таверна")).Click();
            driver.FindElement(By.PartialLinkText("забрать")).Click();

            driver.FindElement(By.PartialLinkText("покупками")).Click();
            driver.FindElement(By.PartialLinkText("взять")).Click();
            driver.FindElement(By.PartialLinkText("Торговля")).Click();
            driver.FindElement(By.PartialLinkText("амуниции")).Click();
            driver.FindElement(By.PartialLinkText("броня")).Click();
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[4]/div/table[1]/tbody/tr/td[2]/div[2]/a")).Click();
            driver.FindElement(By.ClassName("but2")).Click();
            driver.FindElement(By.PartialLinkText("главная")).Click();
            driver.FindElement(By.PartialLinkText("Таверна")).Click();
            driver.FindElement(By.PartialLinkText("забрать")).Click();
            driver.FindElement(By.PartialLinkText("Одевашки")).Click();
            driver.FindElement(By.PartialLinkText("взять")).Click();
            driver.FindElement(By.PartialLinkText("Мешок")).Click();
            driver.FindElement(By.PartialLinkText("одеть")).Click();
            driver.FindElement(By.PartialLinkText("главная")).Click();
            driver.FindElement(By.PartialLinkText("Таверна")).Click();
            driver.FindElement(By.PartialLinkText("забрать")).Click();
            driver.FindElement(By.PartialLinkText("Волков")).Click();
            driver.FindElement(By.PartialLinkText("взять")).Click();
            driver.FindElement(By.PartialLinkText("Приключения")).Click();
            driver.FindElement(By.PartialLinkText("Охота")).Click();
            driver.FindElement(By.PartialLinkText("бить")).Click();
            driver.FindElement(By.PartialLinkText("покинуть бой")).Click();
            driver.FindElement(By.PartialLinkText("Таверна")).Click();
            driver.FindElement(By.PartialLinkText("забрать")).Click();
            driver.FindElement(By.PartialLinkText("сфера")).Click();
            driver.FindElement(By.PartialLinkText("взять")).Click();
            driver.FindElement(By.PartialLinkText("Торговля")).Click();
            driver.FindElement(By.PartialLinkText("Чародей")).Click();
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[4]/div[3]/table[3]/tbody/tr/td[2]/div[2]/a")).Click();
            driver.FindElement(By.ClassName("but2")).Click();
            driver.FindElement(By.PartialLinkText("главная")).Click();
            driver.FindElement(By.PartialLinkText("Таверна")).Click();
            driver.FindElement(By.PartialLinkText("забрать")).Click();
            driver.FindElement(By.PartialLinkText("на стенку")).Click();
            driver.FindElement(By.PartialLinkText("взять")).Click();
            driver.FindElement(By.PartialLinkText("Приключения")).Click();
            driver.FindElement(By.PartialLinkText("Арена")).Click();
            driver.FindElement(By.PartialLinkText("главная")).Click();
            driver.FindElement(By.PartialLinkText("Таверна")).Click();
            driver.FindElement(By.PartialLinkText("забрать")).Click();
            driver.FindElement(By.ClassName("but3")).Click();
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[4]/p[2]/a")).Click();
            driver.FindElement(By.PartialLinkText("взять")).Click();
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[4]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[6]/form/input[2]")).Click();
            driver.FindElement(By.ClassName("butt")).Click();
            driver.FindElement(By.PartialLinkText("главная")).Click();
            driver.FindElement(By.PartialLinkText("Таверна")).Click();
            driver.FindElement(By.PartialLinkText("забрать")).Click();
            driver.FindElement(By.PartialLinkText("Схватка")).Click();
            driver.FindElement(By.PartialLinkText("взять")).Click();
            Shvatka("Бой");
            driver.FindElement(By.PartialLinkText("покинуть")).Click();
            driver.FindElement(By.PartialLinkText("забрать")).Click();
            driver.FindElement(By.ClassName("butt")).Click();
            driver.FindElement(By.PartialLinkText("Званый ужин")).Click();
            driver.FindElement(By.PartialLinkText("Скакать")).Click();
            driver.FindElement(By.PartialLinkText("Приключения")).Click();
            driver.FindElement(By.PartialLinkText("Окрестности")).Click();
            driver.FindElement(By.PartialLinkText("Полис Пирия - болота")).Click();
            while (true)
            {
                if (IsElementCon("Далее"))
                {
                    if (IsElementCon("достижение"))
                        driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[4]/div[1]/table/tbody/tr/td[3]/div/div[2]/a")).Click();
                    else
                        driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[3]/div[4]/div[1]/table/tbody/tr/td[3]/div/div[2]/a")).Click();
                    Shvatka("Ты выиграл.");
                    driver.FindElement(By.PartialLinkText("покинуть")).Click();
                }
                else break;
            }
            driver.FindElement(By.PartialLinkText("Далее")).Click();
            driver.FindElement(By.PartialLinkText("Таверна")).Click();
            driver.FindElement(By.PartialLinkText("Аномалия")).Click();
            driver.FindElement(By.PartialLinkText("Хм")).Click();
            driver.FindElement(By.PartialLinkText("Приключения")).Click();
            driver.FindElement(By.PartialLinkText("Окрестности")).Click();
            driver.FindElement(By.PartialLinkText("Полис Пирия - болота")).Click();
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[4]/div[2]/table/tbody/tr/td[3]/div/div[2]/a")).Click();

            Shvatka("Бой завершен");
            driver.FindElement(By.PartialLinkText("покинуть бой")).Click();
            driver.FindElement(By.PartialLinkText("главная")).Click();
            driver.FindElement(By.PartialLinkText("Таверна")).Click();
            driver.FindElement(By.PartialLinkText("забрать")).Click();
            driver.FindElement(By.PartialLinkText("главная")).Click();

            //приоденемся
            driver.FindElement(By.PartialLinkText("Мешок")).Click();
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[4]/table[2]/tbody/tr/td[2]/div[2]/a[1]")).Click();
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[3]/div[4]/table[3]/tbody/tr/td[2]/div[2]/a[1]")).Click();
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[3]/div[4]/table[4]/tbody/tr/td[2]/div[2]/a")).Click();
            driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[3]/div[4]/table[4]/tbody/tr/td[2]/div[2]/a[1]")).Click();


            driver.FindElement(By.PartialLinkText("главная")).Click();
            //driver.FindElement(By.PartialLinkText("Приключения")).Click();
            //driver.FindElement(By.PartialLinkText("Окрестности")).Click();
            //driver.FindElement(By.PartialLinkText("Полис Пирия - болота")).Click();
            //while (true)
            //{
            //    if (IsElementCon("Далее"))
            //    {
            //        driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[4]/div[3]/table/tbody/tr/td[3]/div/div[2]/a")).Click();
            //        Shvatka("Бой завершен");
            //        driver.FindElement(By.PartialLinkText("покинуть бой")).Click();
            //        System.Threading.Thread.Sleep(15000);
            //        driver.Navigate().Refresh();
            //    }
            //    else break;
            //}
            ////driver.FindElement(By.PartialLinkText("Далее")).Click();
            ////приоденемся
            ////driver.FindElement(By.PartialLinkText("Мешок")).Click();
            ////driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[4]/table[2]/tbody/tr/td[2]/div[2]/a[1]")).Click();

            //driver.Navigate().GoToUrl("http://teeda.mgates.ru/game/");
            driver.FindElement(By.PartialLinkText("Приключения")).Click();
            driver.FindElement(By.PartialLinkText("Окрестности")).Click();
            driver.FindElement(By.PartialLinkText("Полис Пирия - болота")).Click();
            
            for (int i = 0; i < 8; i++)
            {
                driver.FindElement(By.XPath(@"//*[@id='containerAPI']/div[1]/div[2]/div[4]/div[3]/table/tbody/tr/td[3]/div/div[2]/a")).Click();
                Shvatka("Бой завершен");
                driver.FindElement(By.PartialLinkText("покинуть бой")).Click();
                System.Threading.Thread.Sleep(15000);
                driver.Navigate().Refresh();
            }

            driver.FindElement(By.PartialLinkText("приключения")).Click();
            driver.FindElement(By.PartialLinkText("Штурм")).Click();
            Shvatka("воскреснуть");
            driver.FindElement(By.PartialLinkText("воскреснуть")).Click();
            driver.FindElement(By.PartialLinkText("главная")).Click();
            System.Threading.Thread.Sleep(15000);
            driver.Navigate().Refresh();







        }

    }
}
