﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using WD_Tests.WizzAir;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HW1.PageObjects
{
    public class WizzAirHomePage : WizzAirBasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public WizzAirHomePage(IWebDriver driver, WebDriverWait wait) : base (driver, wait)
        {
            _driver = driver;
            _wait = wait;
            WaitForDocumentReady();
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

        public WizzAirSelectFlightPage Search()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(Navigation.SearchBtn)).Click();
            _driver.SwitchTo().Window(_driver.WindowHandles.First()).Close();
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
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