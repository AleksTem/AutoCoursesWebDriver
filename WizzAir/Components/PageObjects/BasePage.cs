using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WizzAir.Utils.Configs;
using WizzAir.Utils.Helpers;

namespace WizzAir.Components.PageObjects
{
    public class BasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public BasePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void WaitForBlocker()
        {            
            _wait.Timeout = DriverConfig.MiddleWait;
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".loader-combined")));
            _wait.Timeout = DriverConfig.LowWait;
        }

    }
}
