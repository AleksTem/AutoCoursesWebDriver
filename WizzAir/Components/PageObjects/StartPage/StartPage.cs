using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;
using System.Reflection;
using WizzAir.Components.Enums;
using WizzAir.Components.Models;


namespace WizzAir.Components.PageObjects
{
    public class StartPage : BasePage
    {
        #region Fields
        private IWebDriver _driver;
        private WebDriverWait _wait;
        #endregion

        #region Constructor
        public StartPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
            WaitForDocumentReady();
        }
        #endregion



        public StartPage SetOriginAirPort(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException($"Airport name is Null or Empty : {MethodBase.GetCurrentMethod().Name}");
            }
            return SetAirPort(Airport.Departure, value);
        }

        public StartPage SetDestinationAirport(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException($"Airport name is Null or Empty : {MethodBase.GetCurrentMethod().Name}");
            }
            return SetAirPort(Airport.Arrival, value);
        }

        /// <summary>
        /// Selects FlightDetails.DepartureDate on calendar, or picks up nearest available date, if FlightDetails.DepartureDate == null
        /// </summary>
        /// <param name="flight"></param>
        /// <returns>StartPage, in param flight set selected date</returns>
        public StartPage SetDepartureDate(ref FlightDetails flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException($"Flight details is null : {MethodBase.GetCurrentMethod().Name}");
            }
            if (flight.DepartureDate.Equals(null))
            {
                DepartureDate.Click();
                return new CalendarPopUp(_driver, _wait)
                    .PickFirstAvailableDate(Direction.Departure, ref flight);
            }
            else throw new NotImplementedException("Set particular departure date is not implemented yet.");
        }

        /// <summary>
        /// Selects FlightDetails.ReturnDate on calendar, or performs OneWayOnly.Click, if FlightDetails.DepartureDate == null
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        public StartPage SetReturnDate(ref FlightDetails flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException($"Flight details is null : {MethodBase.GetCurrentMethod().Name}");
            }
            else
            {
                if (flight.ReturnDate == null)
                {
                    ReturnDate.Click();
                    return new CalendarPopUp(_driver, _wait).SelectOneWayOnly();
                }
                else
                {
                    throw new NotImplementedException("Set particular date not implemented yet.");
                }
            }
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

        #region Properties

        private IWebElement DepartureDate => _wait.Until(ExpectedConditions.ElementToBeClickable(FlightDate.DepartureDate));
        private IWebElement ReturnDate => _wait.Until(ExpectedConditions.ElementToBeClickable(FlightDate.ReturnDate));
        #endregion


    }
}
