using HW1;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Tests
{
    public class BaseFixture
    {
        protected IWebDriver driver;
        protected string homeURL;
        protected WebDriverWait wait;

        [OneTimeSetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = Config.ImplicitWait;
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [OneTimeTearDown]
        public void TearDownTest()
        {
            driver.Dispose();
        }

    }
}
