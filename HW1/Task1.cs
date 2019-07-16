using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW1
{
    [TestFixture, Description("WD Practice Part1. Gismeteo.ua")]
    public class Task1
    {
        private IWebDriver driver;
        private readonly string homeURL = "https://www.gismeteo.ua/";

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Dispose();
        }


        static List<By> listFindAllDivsTest = new List<By>
        {
            By.CssSelector("div"),
            By.TagName("div"),
            By.XPath("//div")
        };

        [Test, TestCaseSource("listFindAllDivsTest")]
        [Description("Find all divs on the page")]
        public void FindAllDivsTest(By selectBy)
        {
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            Assert.That(divsList, Has.Count.Not.LessThan(300));
        }


        static List<By> listFindAllDivsWithH2ClassTest = new List<By>
        {
            By.CssSelector("._line.timeline"),
            By.ClassName("timeline"),
            By.XPath(".//*[contains(@class, 'timeline')]")
        };

        [Test, TestCaseSource("listFindAllDivsWithH2ClassTest")]
        [Description("Find all divs with '_line timeline clearfix' class")]
        public void FindAllDivsWithH2ClassTest(By selectBy)
        {
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            Assert.That(divsList, Has.Count.EqualTo(1));
        }


        static List<By> listFindAllSpansWithNewsTitleTest = new List<By>
        {
            By.CssSelector(".readmore_title"),
            By.ClassName("readmore_title"),
            By.XPath(".//*[contains(@class, 'readmore_title')]")
        };

        [Test, TestCaseSource("listFindAllSpansWithNewsTitleTest")]
        [Description("Find all spans with news titles(the block under list of cities)(6 items)")]
        //Actually should: Find all divs
        public void FindAllSpansWithNewsTitleTest(By selectBy)
        {
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            Assert.That(divsList, Has.Count.EqualTo(4));
        }



        static List<By> listFindLastSpanWithNewsTitleTest = new List<By>
        {
            By.CssSelector(".readmore_item:last-child"),
            By.XPath("//*[@class='readmore_list']/*[last()]")
        };

        [Test, TestCaseSource("listFindLastSpanWithNewsTitleTest")]
        [Description("Find the last span with news title")]
        public void FindLastSpanWithNewsTitleTest(By selectBy)
        {
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            Assert.That(divsList, Has.Count.EqualTo(1));
        }


        static List<By> listGetAllTitlesFromNews = new List<By>
        {
            By.CssSelector(".readmore_title"),
            By.ClassName("readmore_title"),
            By.XPath("//*[contains(@class, 'readmore_title')]")
        };

        [Test, TestCaseSource("listGetAllTitlesFromNews")]
        [Description("Get all titles from items from #3")]
        public void GetAllTitlesFromNewsTest(By selectBy)
        {
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            List<string> titles = divsList.Select(el => el.Text).ToList();
            Assert.That(titles, Has.Count.EqualTo(4));
        }

        [Test]
        [Description("Find element with text Киев")]
        public void FindElementWithTextKievTest()
        {
            string selector = "//span[contains(.,'Киев')]";
            By selectBy = By.XPath(selector);

            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> elelementsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            Assert.That(elelementsList, Has.Count.EqualTo(1));
        }

        [Test]
        [Description("Find the element that describes city next after Киев")]
        public void FindElementWithCityAfterKievTest()
        {
            string selector = "//span[text()='Киев']/../../following-sibling::div[1]";
            By selectBy = By.XPath(selector);

            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> elelementsList = wait.Until(d => d.FindElements(selectBy)).ToList();

            Assert.That(elelementsList, Has.Count.EqualTo(1));
        }


        static List<By> listGetAllTopMenuLinksTest = new List<By>
        {
            By.CssSelector(".nav_type_menu a"),
            By.XPath("//*[contains(@class,'nav_type_menu')]//descendant::a")
        };

        [Test, TestCaseSource("listGetAllTopMenuLinksTest")]
        [Description(" Find all top menu link ")]
        public void GetAllTopMenuLinksTest(By selectBy)
        {
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            List<string> titles = divsList.Select(el => el.Text).ToList();
            Assert.That(titles, Has.Count.EqualTo(4));
        }


        static List<By> listGetElementForThreeWeekdaysTest = new List<By>
        {
            By.CssSelector(""),
            By.XPath("")
        };

        [Test, TestCaseSource("listGetElementForThreeWeekdaysTest")]
        [Description(" On the current city weather page find element for 3 current weekdays. ")]
        [Ignore("unfinished")]
        public void GetElementForThreeWeekdaysTest(By selectBy)
        {
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector("a[href*='month']"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(selectBy));
            List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            Assert.That(divsList, Has.Count.EqualTo(4));
        }


    }
}
