﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HW1.PageObjects
{
    public class WizzAirBasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public WizzAirBasePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void WaitForDocumentReady()
        {
            while (true)
            {
                if (((IJavaScriptExecutor) _driver).ExecuteScript("return document.readyState").Equals("complete"))
                {
                    break;
                }
                Thread.Sleep(100);
            }
        }

        public void WaitForBlocker()
        {
            //_wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".flight-search__panel.flight-search__panel--sub.flight-search__panel--sub--date.loader-combined")));
            //_wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".loader-combined")));
            _wait.Timeout = TimeSpan.FromSeconds(50);
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".loader-combined")));
        }
    }
}
