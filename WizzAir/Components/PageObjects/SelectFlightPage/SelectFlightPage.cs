using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizzAir.Components.Models;

namespace WizzAir.Components.PageObjects
{
    class SelectFlightPage : BasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public SelectFlightPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
            _wait.Timeout = TimeSpan.FromSeconds(10);
            //_wait.Until(ExpectedConditions.ElementExists(By.TagName("body")));
            WaitForDocumentReady();
        }

        public void VerifyContent(FlightDetails expected)
        {

            /*- Verify:
                    flight date
                    arrival/destination points
                    correct date is selected
                    3 options with different prices are displayed, check prices
                    return flights are not displayed
            */
            Assert.That(Route.Text, Does.Contain(expected.DepartureAirport).And.Contain(expected.ArrivalAirport));
            var result = DateTime.TryParse(FlightDate.GetAttribute("datetime"), out DateTime flightDateOnUI);
            if (!result)
            {
                throw new Exception("Failed date parsing in VerifyContent()");
            }
            Assert.That(flightDateOnUI, Is.EqualTo(expected.DepartureDate));
            Assert.That(ReturnFlightBlock.Count, Is.EqualTo(0));
            WaitForBlocker();
            PriceButton.Click();
        }

        private IWebElement Route => _wait.Until(ExpectedConditions.ElementExists(SelectFlightElements.Address));
        private IWebElement FlightDate => _wait.Until(ExpectedConditions.ElementExists(SelectFlightElements.FlightDate));
        private ReadOnlyCollection<IWebElement> ReturnFlightBlock => _driver.FindElements(SelectFlightElements.ReturnFlight);
        private IWebElement PriceButton => _wait.Until(ExpectedConditions.ElementExists(SelectFlightElements.PriceButton));
    }
}
