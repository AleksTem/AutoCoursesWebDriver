using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizzAir.Components.PageObjects
{
    public static class PassengerPageElements
    {
        public static By FirstNameInput => By.Id("passenger-first-name-0");
        public static By LastNameInput => By.Id("passenger-last-name-0");
        public static By Male => By.CssSelector("[for='passenger-gender-0-male']");
        public static By Female => By.CssSelector("[for='passenger-gender-0-female']");
        public static By RouteOnTop => By.ClassName("booking-flow__itinerary__route");
        public static By LaggageOption0 => By.CssSelector("[for='passenger-0-outbound-checked-in-baggage-switch-option0']");
        public static By LaggageOption1 => By.CssSelector("[for='passenger-0-outbound-checked-in-baggage-switch-option1']");
        public static By LaggageOption2 => By.CssSelector("[for='passenger-0-outbound-checked-in-baggage-switch-option2']");
        public static By ContinueBtn => By.Id("passengers-continue-btn");
    }
}
