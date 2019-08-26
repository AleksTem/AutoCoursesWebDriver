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
using WD_Tests;
using WizzAir.Components.Enums;
using WizzAir.Components.Models;
using WizzAir.Utils.Configs;
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
            
            //var t = PriceBlockDiv;
            //_driver.ScrollToElement(t);
            //WizzGoPrice.Click();

            //_driver.WaitForDocumentReadyState();
            PriceButton.Click();
            _driver.WaitForDocumentReadyState();
            //_driver.ScrollWindowDown();
            _driver.ScrollToElement(ScrollAnchor);
            _driver.ClickViaAction(PriceButton);
            _driver.WaitForDocumentReadyState();

            //switch (priceLevel)
            //{
            //    case ServiceLevel.WizzBasic:
            //        //_driver.ScrollToElement(WizzBasicPrice);
            //        _driver.ClickViaAction(WizzBasicPrice);
            //        break;
            //    case ServiceLevel.WizzGo:
            //        //_driver.ScrollToElement(WizzGoPrice);
            //        _driver.ClickViaAction(WizzGoPrice);
            //        break;
            //    case ServiceLevel.WizzPlus:
            //        //_driver.ScrollToElement(WizzPlusPrice);
            //        _driver.ClickViaAction(WizzPlusPrice);
            //        break;
            //}
            return this;
        }

        public PassengerPage ContinueSelect()
        {
            
            _driver.WaitForDocumentReadyState();
            _driver.ScrollWindowDown();
            var t = FlightSelectContinueButton;
            //_driver.ScrollIntoViewJS(t);
            _driver.ScrollWindowDown();
            _wait.Timeout = DriverConfig.ExtraWait;
            _wait.Until(CustomConditions.WizzElementBeEnabled(t));
            
            t.Click();
            _wait.Until(CustomConditions.WizzElementBeEnabled(t));
            _wait.Timeout = DriverConfig.LowWait;
            _driver.WaitForDocumentReadyState();
            
            return new PassengerPage(_driver, _wait);
        }

        //public Selectflight

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
            _wait.Until(ExpectedConditions.ElementToBeClickable(SelectFlightElements.Address));
        private IWebElement FlightDateElem => 
            _wait.Until(ExpectedConditions.ElementToBeClickable(SelectFlightElements.FlightDate));
        private ReadOnlyCollection<IWebElement> ReturnFlightBlock => 
            _driver.FindElements(SelectFlightElements.ReturnFlight);
        private IWebElement PriceButton => 
            _wait.Until(ExpectedConditions.ElementExists(SelectFlightElements.PriceButton));

        private IWebElement ScrollAnchor => _wait.Until(
            ExpectedConditions.ElementIsVisible(SelectFlightElements.ScrollAnchor));

        private IWebElement WizzBasicPrice
        {
            get
            {
                IWebElement element = _driver.FindElement(SelectFlightElements.WizzGoPriceButton);
                _driver.ScrollIntoViewJS(element);
                return _wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
        }
            
        private IWebElement WizzPlusPrice
        {
            get
            {
                IWebElement element = _driver.FindElement(SelectFlightElements.WizzGoPriceButton);
                _driver.ScrollIntoViewJS(element);
                return _wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
        } 
            
        private IWebElement WizzGoPrice
        {
            get
            {
                IWebElement element = _driver.FindElement(SelectFlightElements.WizzGoPriceButton);
                _driver.ScrollIntoViewJS(element);
                return _wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
        }

        private IWebElement FlightSelectContinueButton
        { get
            {
                _driver.WaitForDocumentReadyState();
                _wait.Timeout = DriverConfig.ExtraWait;
                _wait.Until(ExpectedConditions.ElementIsVisible(SelectFlightElements.ContinueButton));
                _wait.Until(ExpectedConditions.ElementToBeClickable(SelectFlightElements.ContinueButton));
                _wait.Timeout = DriverConfig.LowWait;
                return _driver.FindElement(SelectFlightElements.ContinueButton);
            }
        }

        
            
    }
}
