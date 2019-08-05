using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace WD_Tests
{
    public class BaseFixture
    {
        protected IWebDriver Driver;
        ////protected string HomeURL;
        protected WebDriverWait Wait;

        [OneTimeSetUp]
        public void SetupTest()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = DriverConfig.NoWait;
            Driver.Manage().Window.Maximize();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }

        [OneTimeTearDown]
        public void TearDownTest()
        {
            //Driver.Quit();
        }

    }
}
