using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        public void WaitForDocumentReady()
        {
            while (true)
            {
                if (((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"))
                {
                    break;
                }
                Thread.Sleep(100);
            }
        }

        public void WaitForBlocker()
        {
            TimeSpan temp = _wait.Timeout;
            _wait.Timeout = TimeSpan.FromSeconds(120);
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".loader-combined")));
            _wait.Timeout = temp;
        }

    }
}
