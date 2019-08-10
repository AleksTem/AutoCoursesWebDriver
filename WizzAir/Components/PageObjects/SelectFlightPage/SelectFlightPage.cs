using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WizzAir.Components.Enums;
using WizzAir.Components.Models;

namespace WizzAir.Components.PageObjects
{
    public class SelectFlightPage : BasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public SelectFlightPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
            _wait.Timeout = TimeSpan.FromSeconds(10);
            WaitForDocumentReady();
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

        public void ChoosePrice(ServiceLevel priceLevel)
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
        private IWebElement WizzBasicPrice => 
            _wait.Until(ExpectedConditions.ElementToBeClickable(SelectFlightElements.WizzBasicPriceButton));
        private IWebElement WizzPlusPrice => 
            _wait.Until(ExpectedConditions.ElementToBeClickable(SelectFlightElements.WizzBasicPriceButton));
        private IWebElement WizzGoPrice => 
            _wait.Until(ExpectedConditions.ElementToBeClickable(SelectFlightElements.WizzBasicPriceButton));



    }
}
