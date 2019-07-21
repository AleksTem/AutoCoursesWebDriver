using HW1;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    [Description("WD Practice Part1. Gismeteo.ua")]
    public class GismeteoTests : BaseFixture
    {
        [OneTimeSetUp]
        public void SetUpFixture()
        {
            homeURL = "https://www.gismeteo.ua/";
            driver.Navigate().GoToUrl(homeURL);
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
            List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            List<string> titles = divsList.Select(el => el.Text).ToList();
            Assert.That(titles, Has.Count.EqualTo(4));
        }
        [Order(6)]
        [Test]
        [Description("Find element with text Киев")]
        public void FindElementWithTextKievTest()
        {
            string selector = "//span[contains(.,'Киев')]";
            By selectBy = By.XPath(selector);

            List<IWebElement> elelementsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            Assert.That(elelementsList, Has.Count.EqualTo(1));
        }
        [Order(7)]
        [Test]
        [Description("Find the element that describes city next after Киев")]
        public void FindElementWithCityAfterKievTest()
        {
            string selector = "//span[text()='Киев']/../../following-sibling::div[1]";
            By selectBy = By.XPath(selector);

            List<IWebElement> elelementsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            Assert.That(elelementsList, Has.Count.EqualTo(1));
        }

        // # 8
        static List<By> listGetAllTopMenuLinksTest = new List<By>
        {
            By.CssSelector(".nav_type_menu a"),
            By.XPath("//*[contains(@class,'nav_type_menu')]//descendant::a")
        };
        [Order(8)]
        [Test, TestCaseSource("listGetAllTopMenuLinksTest")]
        [Description(" Find all top menu link ")]
        public void GetAllTopMenuLinksTest(By selectBy)
        {
            List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            List<string> titles = divsList.Select(el => el.Text).ToList();
            Assert.That(titles, Has.Count.EqualTo(4));
        }

        // # 9
        static List<By> listGetElementForThreeWeekdaysTest = new List<By>
        {
            By.CssSelector("a[href*='3-days']"),
            By.XPath("//a[contains(@href, '3-days')]")
        };
        [Order(9)]
        [Test, TestCaseSource("listGetElementForThreeWeekdaysTest")]
        [Description(" On the current city weather page find element for 3 current weekdays. ")]
        public void GetElementForThreeWeekdaysTest(By selectBy)
        {
            List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            Assert.That(divsList, Has.Count.EqualTo(1));
        }

        // # 10
        static List<By> listGetElementForCurrentlySelectedweekdayTest = new List<By>
        {
            By.CssSelector("li.nolink:first-child > a"),
            By.XPath("//li[contains(@class, 'nolink')][1]/a")
        };
        [Order(10)]
        [Test, TestCaseSource("listGetElementForCurrentlySelectedweekdayTest")]
        [Description("Find element for currently selected weekday")]
        public void GetElementForCurrentlySelectedweekdayTest(By selectBy)
        {
            List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy)).ToList();
            Assert.That(divsList, Has.Count.EqualTo(1));
        }


        // # 11
        static List<Tuple<By, By>> listGetElementWhenMainlyClearTest = new List<Tuple<By, By>>
        {
            Tuple.Create(By.CssSelector("[data-icon='n_c2']"),
            By.CssSelector("[data-type='temperature']")),
            Tuple.Create(By.XPath("//*[@data-icon='n_c2']"),
                By.XPath("//*[@data-type='temperature']"))
        };

        [Order(11)]
        [Test, TestCaseSource("listGetElementWhenMainlyClearTest")]
        [Description("Find temperature when it's Малооблачно (1 element!!)")]
        public void GetElementWhenMainlyClearTest(Tuple<By, By> selectBy)
        {
            if (driver.ElementIsPresent(selectBy.Item1))
            {
                List<IWebElement> divsList = wait.Until(d => d.FindElements(selectBy.Item2)).ToList();
                Assert.That(divsList, Has.Count.EqualTo(1).And.Not.Null);
            }
            else
            {
                Assert.Fail("There is no element 'Малооблачно' on the page");
            }
        }
    }
}
