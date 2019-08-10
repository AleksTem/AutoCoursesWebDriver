using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WizzAir.Utils.Configs;

namespace WizzAirTests
{
    public class BaseFixture
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        [OneTimeSetUp]
        public void SetupTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = DriverConfig.NoWait;
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        [OneTimeTearDown]
        public void TearDownTest()
        {
            _driver.Quit();
        }

    }
}
