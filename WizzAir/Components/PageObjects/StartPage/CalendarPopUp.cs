using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WizzAir.Components.Enums;
using WizzAir.Components.Models;
using WizzAir.Utils.Helpers;

namespace WizzAir.Components.PageObjects
{
    class CalendarPopUp : BasePage
    {
        IWebDriver _driver;
        WebDriverWait _wait;

        public CalendarPopUp(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public StartPage PickFirstAvailableDate(Direction direction, ref FlightDetails flight)
        {
            IWebElement pickedDate = AvailableDatesList[5];//.FirstOrDefault();
            if (direction == Direction.Departure)
            {
                flight.DepartureDate = ParseDateFromCalendarElement(pickedDate);
            }
            else
            {
                flight.ReturnDate = ParseDateFromCalendarElement(pickedDate);
            }
            pickedDate.Click();
            WaitForBlocker();
            Retry.Do(()=> OkButton.Click(),TimeSpan.FromSeconds(5), maxAttemptCount: 10);
            return new StartPage(_driver, _wait);
        }

        public StartPage SelectOneWayOnly()
        {
            Retry.Do(() => OneWayButton.Click(), TimeSpan.FromSeconds(5), maxAttemptCount: 10);
            return new StartPage(_driver, _wait);
        }


        public List<IWebElement> GetAvailableDates()
        {
            return AvailableDatesList;
        }

        public CalendarPopUp PickDate(DateTime? date)
        {
            var t = AvailableDatesList.Where(elem =>          
                date.Equals(ParseDateFromCalendarElement(elem))).ToList();

            return this;
        }

        /// <summary>
        /// Read date from calendar IWebElement
        /// </summary>
        /// <param name="calendarDay"></param>
        /// <returns>Parsed date</returns>
        private DateTime ParseDateFromCalendarElement(IWebElement calendarDay)
        {
            int year = Int32.Parse(calendarDay.GetAttribute("data-pika-year"));
            int month = Int32.Parse(calendarDay.GetAttribute("data-pika-month")) + 1;
            int day = Int32.Parse(calendarDay.GetAttribute("data-pika-day"));
            Assert.That(calendarDay.Text, Is.EqualTo(day.ToString()));
            return new DateTime(year, month, day);
        }

        private List<IWebElement> AvailableDatesList => _wait.Until(ExpectedConditions
                    .VisibilityOfAllElementsLocatedBy(Calendar.AvailableDates)).ToList();
        private IWebElement OkButton => _wait.Until(ExpectedConditions.ElementToBeClickable(Calendar.OkButton));
        private IWebElement OneWayButton => _wait.Until(ExpectedConditions.ElementToBeClickable(Calendar.OneWayOnly));
    }
}
