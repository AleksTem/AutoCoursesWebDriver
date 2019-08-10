using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizzAir.Components.PageObjects
{
    public static class Airport
    {
        public static By Departure => By.Id("search-departure-station");
        public static By Arrival => By.Id("search-arrival-station");
        public static By ConfirmLocation => By.ClassName("locations-container__location__name");
    }

    public static class FlightDate
    {
        public static By DepartureDate => By.Id("search-departure-date"); //By.CssSelector("label.arrival-input");
        public static By ReturnDate => By.Id("search-return-date");
        public static By Arrival => By.CssSelector("label.return-date-input");
        
        
    }

    public static class Calendar
    {
        public static By AvailableDates => By.CssSelector("td[data-day]:not(.is-disabled) > button");
        public static By OneWayOnly => By.XPath("//*[contains(text(),'One way only')]");
        public static By OkButton => By.XPath("//button[contains(text(), 'OK')]");
    }

    public static class Navigation
    {
        public static By SearchBtn => By.CssSelector(".flight-search__panel__fieldset--cta-btn > button");
    }
}
