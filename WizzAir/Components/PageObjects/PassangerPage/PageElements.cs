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
    }
}
