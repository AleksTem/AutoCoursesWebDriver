using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using WD_Tests.WizzAir;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HW1.PageObjects
{
    public class WizzAirHomePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public WizzAirHomePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }




        public WizzAirHomePage SetOriginAirPort(string value)
        {
            return SetAirPort(Airport.Departure, value);
        }

        public WizzAirHomePage SetDestinationAirport(string value)
        {
            return SetAirPort(Airport.Arrival, value);
        }

        public WizzAirHomePage SetDepartureDate(ref FlightDetail flight)
        {
            if (flight.DepartureDate.Equals(null))
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(FlightDate.Departure)).Click();
                IWebElement date = _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(FlightDate.AvailableDates)).ToList().FirstOrDefault();
                int year = Int32.Parse(date.GetAttribute("data-pika-year"));
                int month = Int32.Parse(date.GetAttribute("data-pika-month"));
                int day = Int32.Parse(date.GetAttribute("data-pika-day"));
                Assert.That(date.Text, Is.EqualTo(day.ToString()));

                flight.DepartureDate = new DateTime(year, month, day);

                if (flight.ReturnDate.Equals(null))
                {
                    _wait.Until(ExpectedConditions.ElementToBeClickable(FlightDate.OneWayOnly)).Click();
                    return this;
                }
                else throw new Exception("Not implemented yet.");
            }
            else throw new Exception("Not implemented yet.");
        }

        public WizzAirSelectFlightPage Search()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(Navigation.SearchBtn)).Click();
            return new WizzAirSelectFlightPage(_driver, _wait);
        }

        private WizzAirHomePage SetAirPort(By selector, string value)
        {
            IWebElement inputElement = _wait.Until(ExpectedConditions.ElementExists(selector));
            inputElement.Clear();
            inputElement.SendKeys(value);
            inputElement.Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(Airport.ConfirmLocation)).Click();

            return this;
        }

    }
}
