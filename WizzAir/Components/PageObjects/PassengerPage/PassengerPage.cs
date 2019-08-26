using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WizzAir.Components.Enums;
using WizzAir.Components.Models;
using WizzAir.Utils.Extensions;

namespace WizzAir.Components.PageObjects
{
    public class PassengerPage : BasePage
    {
        IWebDriver _driver;
        WebDriverWait _wait;
        public PassengerPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
            _driver.WaitForDocumentReadyState();
        }

        public PassengerPage FillInPassangerDetails(Passenger p)
        {
            FirstName.Clear();
            FirstName.SendKeys(p.FirstName);
            LastName.Clear();
            LastName.SendKeys(p.LastName);
            return  PickGender(p);
        }

        private PassengerPage PickGender(Passenger p)
        {
            _driver.WaitForDocumentReadyState();
            IWebElement elem = p.Gender ? Male : Female;
            new Actions(_driver).MoveToElement(elem).Click().Build().Perform();
            return this;
        }

        public PassengerPage VerifyRoute(FlightDetails flight)
        {
            string textRoute = Route.Text.ToLower();
            Assert.Multiple(()=> 
            {
                StringAssert.Contains(flight.DepartureAirport.ToLower(), textRoute);
                StringAssert.Contains(flight.ArrivalAirport.ToLower(), textRoute);
            });
            
            return this;
        }

        public PassengerPage PickLaggage(Luggage option = Luggage.Option_1)
        {
            IWebElement optionToCheck;
            switch (option)
            {
                case Luggage.Option_0:
                    optionToCheck = Laggage0;
                    break;
                case Luggage.Option_2:
                    optionToCheck = Laggage2;
                    break;
                default: optionToCheck = Laggage1;
                    break;
            }
            new Actions(_driver).MoveToElement(optionToCheck).Click().Build().Perform();
            return this;
        }

        public SignInPage Continue()
        {
            ContinueBtn.Click();
            return new SignInPage(_driver, _wait);
        }

        private IWebElement FirstName => _wait.Until(ExpectedConditions.ElementIsVisible(PassengerPageElements.FirstNameInput));
        private IWebElement LastName => _wait.Until(ExpectedConditions.ElementIsVisible(PassengerPageElements.LastNameInput));
        private IWebElement Male => _wait.Until(ExpectedConditions.ElementIsVisible(PassengerPageElements.Male));
        private IWebElement Female => _wait.Until(ExpectedConditions.ElementToBeClickable(PassengerPageElements.Female));
        private IWebElement Route => _wait.Until(ExpectedConditions.ElementIsVisible(PassengerPageElements.RouteOnTop));
        private IWebElement Laggage0 => _wait.Until(ExpectedConditions.ElementIsVisible(PassengerPageElements.LaggageOption0));
        private IWebElement Laggage1 => _wait.Until(ExpectedConditions.ElementIsVisible(PassengerPageElements.LaggageOption1));
        private IWebElement Laggage2 => _wait.Until(ExpectedConditions.ElementIsVisible(PassengerPageElements.LaggageOption2));
        private IWebElement ContinueBtn
        {
            get
            {
                _driver.ScrollWindowDown();
                return _wait.Until(ExpectedConditions.ElementToBeClickable(PassengerPageElements.ContinueBtn));
            }
        }
    }
}
