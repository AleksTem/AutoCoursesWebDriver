using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizzAir.Components.Models;


namespace WizzAir.Components.PageObjects
{
    class StartPage : BasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public StartPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
            WaitForDocumentReady();
        }




        public StartPage SetOriginAirPort(string value)
        {
            return SetAirPort(Airport.Departure, value);
        }

        public StartPage SetDestinationAirport(string value)
        {
            return SetAirPort(Airport.Arrival, value);
        }

        public StartPage SetDepartureDate(ref FlightDetails flight)
        {
            if (flight.DepartureDate.Equals(null))
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(FlightDate.Departure)).Click();
                IWebElement flightDateElement = _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(FlightDate.AvailableDates)).ToList()[5];//.FirstOrDefault();
                int year = Int32.Parse(flightDateElement.GetAttribute("data-pika-year"));
                int month = Int32.Parse(flightDateElement.GetAttribute("data-pika-month")) + 1;
                int day = Int32.Parse(flightDateElement.GetAttribute("data-pika-day"));
                Assert.That(flightDateElement.Text, Is.EqualTo(day.ToString()));
                flightDateElement.Click();

                flight.DepartureDate = new DateTime(year, month, day);

                if (flight.ReturnDate.Equals(null))
                {
                    _wait.Until(ExpectedConditions.ElementToBeClickable(FlightDate.OneWayOnly));
                    WaitForDocumentReady();
                    WaitForBlocker();
                    _wait.Until(ExpectedConditions.ElementExists(FlightDate.OneWayOnly)).Click();
                    return this;
                }
                else throw new Exception("Not implemented yet.");
            }
            else throw new Exception("Not implemented yet.");
        }

        public SelectFlightPage Search()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(Navigation.SearchBtn)).Click();
            _driver.SwitchTo().Window(_driver.WindowHandles.First()).Close();
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            return new SelectFlightPage(_driver, _wait);
        }

        private StartPage SetAirPort(By selector, string value)
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
