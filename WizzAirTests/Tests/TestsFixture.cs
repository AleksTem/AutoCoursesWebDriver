using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizzAir.Utils.Configs;
using WizzAir.Components.PageObjects;
using WizzAir.Components.Models;
using WizzAir.Components.Enums;

namespace WizzAirTests.Tests
{
    [TestFixture]
    class TestsFixture : BaseFixture
    {
        StartPage startPage;

        [OneTimeSetUp]
        public void SetUpFixture()
        {
            _driver.Navigate().GoToUrl(ApplicationConfig.BaseUrl);
            startPage = startPage ?? new StartPage(_driver, _wait);
        }

        [Test]
        public void CustomScenarioTest()
        {
            var flight = new FlightDetails
            {
                DepartureAirport = "Kyiv - Zhulyany",
                ArrivalAirport = "Copenhagen",
                DepartureDate = null,
                ReturnDate = null
            };

            startPage.SetOriginAirPort(flight.DepartureAirport)
                .SetDestinationAirport(flight.ArrivalAirport)
                .SetDepartureDate(ref flight)
                .SetReturnDate(ref flight)
                .Search()
                .VerifySelectedFlightContent(flight)
                .ChoosePrice(ServiceLevel.WizzGo)
                .ContinueSelect()
                .FillPassangerName();

        }

    }
}
