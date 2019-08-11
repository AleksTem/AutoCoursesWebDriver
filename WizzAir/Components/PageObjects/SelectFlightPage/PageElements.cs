using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizzAir.Components.PageObjects
{
    public static class SelectFlightElements
    {
        public static By Address => By.CssSelector(".flight-select__flight__title-container__title");
        public static By FlightDate => By.CssSelector(".js-selected time");
        public static By ReturnFlight => By.Id("return-fare-selector");
        public static By PriceButton => By.CssSelector(".fare-type-button__title--active");

        public static By WizzGoPriceButton => By.CssSelector(".flight-select__fare--middle .fare-type-button__title--active");
        public static By WizzPlusPriceButton => By.CssSelector(".flight-select__fare--plus .fare-type-button__title--active");
        public static By WizzBasicPriceButton => By.CssSelector(".flight-select__fare--basic .fare-type-button__title--active");

        public static By ContinueButton => By.Id("flight-select-continue-button");
    }
}
