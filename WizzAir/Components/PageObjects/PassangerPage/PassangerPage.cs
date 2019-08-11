using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WizzAir.Utils.Extensions;

namespace WizzAir.Components.PageObjects
{
    public class PassangerPage : BasePage
    {
        IWebDriver _driver;
        WebDriverWait _wait;
        public PassangerPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
            _driver.WaitForDocumentReadyState();
        }

        public PassangerPage FillPassangerName()
        {
            FirstName.Clear();
            FirstName.SendKeys("Oleksandr");
            LastName.Clear();
            LastName.SendKeys("Kovalenko");
            return this;
        }

        private IWebElement FirstName => _wait.Until(ExpectedConditions.ElementIsVisible(PassengerPageElements.FirstNameInput));
        private IWebElement LastName => _wait.Until(ExpectedConditions.ElementIsVisible(PassengerPageElements.LastNameInput));
    }
}
