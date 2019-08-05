using HW1.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
using WD_Tests.WizzAir;

namespace WD_Tests
{
    //using _ = WizzAirUtils;
    [TestFixture]
    [Description("WD Practice Part2. wizzair.com")]
    public class WizzAirTests : BaseFixture
    {

        private WizzAirHomePage MainWizzairPage;
        [OneTimeSetUp]
        public void SetUpFixture()
        {
            Driver.Navigate().GoToUrl(Config.BaseUrl);
            MainWizzairPage = MainWizzairPage ?? new WizzAirHomePage(Driver, Wait);
        }

        [Test]
        public void CustomScenarioTest()
        {
            var flight = new FlightDetail
            {
                DepartureAirport = "Kyiv - Zhulyany",
                ArrivalAirport = "Copenhagen",
                DepartureDate = null,
                ReturnDate = null
            };

            MainWizzairPage.SetOriginAirPort(flight.DepartureAirport)
                .SetDestinationAirport(flight.ArrivalAirport)
                .SetDepartureDate(ref flight)
                .Search()
                .VerifyContent(flight);



            //Driver.FindElement(By.ClassName("flight-search__panel__cta-btn")).Click();
            //js-magical-width-item js-date-item flight-select__flight-date-picker__day flight-select__flight-date-picker__day--no-flights js-selectable
            //js-magical-width-item js-date-item flight-select__flight-date-picker__day flight-select__flight-date-picker__day--selected js-selected js-selectable
        }



        class FlightSearchResult
        {
            IWebDriver _driver;
            public FlightSearchResult(IWebDriver driver)
            {
                _driver = driver;
            }

            private readonly object Wait;

            //DateTime FlightDate => Wait.
            //ControlDefinition[".flight-select__fare-selector"]
        }
    }
}
