using HW1;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
        }

        [OneTimeTearDown]
        public void TearDownTest()
        {
            driver.Dispose();
        }

    }
}
