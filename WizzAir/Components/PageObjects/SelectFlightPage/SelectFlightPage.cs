using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WizzAir.Components.Enums;
using WizzAir.Components.Models;
using WizzAir.Utils.Extensions;

namespace WizzAir.Components.PageObjects
{
    public class SelectFlightPage : BasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private object driver;

        public SelectFlightPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
            _wait.Timeout = TimeSpan.FromSeconds(10);
            _driver.WaitForDocumentReadyState();
        }

        public SelectFlightPage VerifySelectedFlightContent(FlightDetails expected)
        {
            Assert.That(DepartureDate, Is.EqualTo(expected.DepartureDate));
            Assert.That(RouteElem.Text, Does.Contain(expected.DepartureAirport)
                .And.Contain(expected.ArrivalAirport));

            Assert.That(ReturnFlightBlock.Count, Is.EqualTo(0));
            WaitForBlocker();
            return this;
        }

        public SelectFlightPage ChoosePrice(ServiceLevel priceLevel)
        {
            PriceButton.Click();
            switch (priceLevel)
            {
                case ServiceLevel.WizzBasic:
                    WizzBasicPrice.Click();
                    break;
                case ServiceLevel.WizzGo:
                    WizzGoPrice.Click();
                    break;
                case ServiceLevel.WizzPlus:
                    WizzPlusPrice.Click();
                    break;
            }
            return this;
        }

        public PassangerPage ContinueSelect()
        {
            var t = FlightSelectContinueButton;
            _driver.ScrollIntoView(t);
            t.Click();
            return new PassangerPage(_driver, _wait);
        }

        private DateTime DepartureDate {
            get
            {
                var result = DateTime.TryParse(FlightDateElem.GetAttribute("datetime"), out DateTime flightDateOnUI);
                if (!result)
                {
                    throw new Exception($"Failed date parsing. {MethodBase.GetCurrentMethod().Name}");
                }
                return flightDateOnUI;
            }
        }

        private IWebElement RouteElem => 
            _wait.Until(ExpectedConditions.ElementExists(SelectFlightElements.Address));
        private IWebElement FlightDateElem => 
            _wait.Until(ExpectedConditions.ElementExists(SelectFlightElements.FlightDate));
        private ReadOnlyCollection<IWebElement> ReturnFlightBlock => 
            _driver.FindElements(SelectFlightElements.ReturnFlight);
        private IWebElement PriceButton => 
            _wait.Until(ExpectedConditions.ElementExists(SelectFlightElements.PriceButton));
        private IWebElement WizzBasicPrice
        {
            get
            {
                IWebElement element = _driver.FindElement(SelectFlightElements.WizzGoPriceButton);
                _driver.ScrollIntoView(element);
                return _wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
        }
            
        private IWebElement WizzPlusPrice
        {
            get
            {
                IWebElement element = _driver.FindElement(SelectFlightElements.WizzGoPriceButton);
                _driver.ScrollIntoView(element);
                return _wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
        } 
            
        private IWebElement WizzGoPrice
        {
            get
            {
                IWebElement element = _driver.FindElement(SelectFlightElements.WizzGoPriceButton);
                _driver.ScrollIntoView(element);
                return _wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
        }

        private IWebElement FlightSelectContinueButton
        { get
            {
                _driver.WaitForDocumentReadyState();
                var temp = _wait.Timeout;
                _wait.Timeout = TimeSpan.FromSeconds(60);
                _wait.Until(ExpectedConditions.ElementIsVisible(SelectFlightElements.ContinueButton));
                _wait.Until(ExpectedConditions.ElementToBeClickable(SelectFlightElements.ContinueButton));
                _wait.Timeout = temp;
                return _driver.FindElement(SelectFlightElements.ContinueButton);
            }
        }
            
    }
}
