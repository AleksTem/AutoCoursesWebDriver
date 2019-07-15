using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
            driver.Close();
        }

        [Test(Description = "Find all divs on the page")]
        public void FindAllDivsTest()
        {
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> divsList = wait.Until(d => d.FindElements(By.CssSelector("div"))).ToList();
            Assert.That(divsList, Has.Count.Not.LessThan(300));
        }

        [Test(Description = "Find all divs with h2 class")]
        public void FindAllDivsWithH2ClassTest()
        {
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> divsList = wait.Until(d => d.FindElements(By.CssSelector("div.h2"))).ToList();
            Assert.That(divsList, Has.Count.EqualTo(0));
        }

        [Test(Description = "Find all spans with news titles(the block under list of cities)(6 items)")]
        [Description("Actually should: Find all divs")]
        public void FindAllSpansWithNewsTitleTest()
        {
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> divsList = wait.Until(d => d.FindElements(By.CssSelector(".readmore_item"))).ToList();
            Assert.That(divsList, Has.Count.EqualTo(4));
        }

        [Test(Description = "Find the last span with news title")]
        public void FindLastSpanWithNewsTitleTest()
        {
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> divsList = wait.Until(d => d.FindElements(By.CssSelector(".readmore_item:last-child"))).ToList();
            Assert.That(divsList, Has.Count.EqualTo(1));
        }


        //public static By list = new By[] { By.CssSelector("dfsg"), By.XPath("//a") };

        [Test(Description = "Get all titles from items from #3")]
        //[TestCase("list")]
        public void GetAllTitlesFromNewsTest(By selectBy)
        {
            //string selector = ".readmore_title";
            //By selectBy = By.CssSelector(selector);

            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            List<string> titles = divsList.Select(el => el.Text).ToList();
            Assert.That(titles, Has.Count.EqualTo(4));
        }

        [Test(Description = "Find element with text Киев")]
        public void FindElementWithTextKievTest()
        {
            string selector = "//span[contains(.,'Киев')]";
            By selectBy = By.XPath(selector);

            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> elelementsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            Assert.That(elelementsList, Has.Count.EqualTo(1));
        }

        [Test(Description = "Find the element that describes city next after Киев")]
        public void FindElementWithCityAfterKievTest()
        {
            string selector = "//span[text()='Киев']/../../following-sibling::div[1]";
            By selectBy = By.XPath(selector);

            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            List<IWebElement> elelementsList = wait.Until(d => d.FindElements(selectBy)).ToList();

            Assert.That(elelementsList, Has.Count.EqualTo(1));
        }
    }
}
//     
