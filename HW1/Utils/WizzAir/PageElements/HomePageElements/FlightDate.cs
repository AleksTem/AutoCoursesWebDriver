using OpenQA.Selenium;

namespace WD_Tests.WizzAir
{
    public class FlightDate
    {
        public static By Departure => By.CssSelector("label.arrival-input");
        public static By Arrival => By.CssSelector("label.return-date-input");
        public static By AvailableDates => By.CssSelector("td[data-day]:not(.is-disabled) > button");
        public static By OneWayOnly => By.XPath("//*[contains(text(),'One way only')]");
    }

}
