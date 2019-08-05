using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using WD_Tests.WizzAir;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HW1.PageObjects
{
    public class WizzAirSelectFlightPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public WizzAirSelectFlightPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            _wait.Timeout = TimeSpan.FromSeconds(120);
        }

        public void VerifyContent(FlightDetail expected)
        {
            /*- Verify:
                    flight date
                    arrival/destination points
                    correct date is selected
                    3 options with different prices are displayed, check prices
                    return flights are not displayed
            */
            //_wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".flight-select__flight__title-container__title")));
            string actualRoute = Route.Text;
            Assert.That(actualRoute, Does.Contain(expected.DepartureAirport).And.Contain(expected.ArrivalAirport));
            //_wait.Until(ExpectedConditions.ElementIsVisible())
        }

        public IWebElement Route => _wait.Until(ExpectedConditions.ElementToBeClickable(Outbound.Address));



        //private WizzAirHomePage SetAirPort(By selector, string value)
        //{
        //    IWebElement inputElement = _driver.FindElement(selector);
        //    inputElement.Clear();
        //    inputElement.SendKeys(value);
        //    inputElement.Click();
        //    _wait.Until(ExpectedConditions.ElementToBeClickable(Airport.ConfirmLocation)).Click();

        //    return this;
        //}

    }
}
