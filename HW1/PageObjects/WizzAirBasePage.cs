using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HW1.PageObjects
{
    public class WizzAirBasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public WizzAirBasePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        //public WizzAirBasePage DoSmth()
        //{
        //    return this;
        //}

        //public WizzAirHomePage Fillform()
        //{
        //    return new WizzAirHomePage(_driver);
        //}
    }
}
