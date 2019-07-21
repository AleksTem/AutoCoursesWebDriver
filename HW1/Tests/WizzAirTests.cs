using NUnit.Framework;
using OpenQA.Selenium;

namespace Tests
{
    [TestFixture]
    [Description("WD Practice Part2. wizzair.com")]
    public class WizzAirTests : BaseFixture
    {
        [OneTimeSetUp]
        public void SetUpFixture()
        {
            homeURL = "https://www.wizzair.com/";
            driver.Navigate().GoToUrl(homeURL);
        }

        [Test]
        public void CustomScenarioTest()
        {
            string departureStation = "Kyiv - Borispol";
            string arrivalStation = "Copenhagen";
            IWebElement departure = driver.FindElement(By.Id("search-departure-station"));
            departure.SendKeys(departureStation);
            IWebElement arrival = driver.FindElement(By.Id("search-arrival-station"));
            arrival.SendKeys(arrivalStation);
        }
    }
}
