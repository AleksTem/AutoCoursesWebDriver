using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WizzAir.Utils.Extensions
{
    public static class WebDriverExtensions
    {
        public static void ScrollIntoView(this IWebDriver driver, IWebElement element)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(nameof(driver));
            }
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);
        }

        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(nameof(driver));
            }
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            new Actions(driver).MoveToElement(element).Perform();
        }

        public static void WaitForDocumentReadyState(this IWebDriver driver)
        {
            while (true)
            {
                if (((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"))
                {
                    break;
                }
                Thread.Sleep(100);
            }
        }

        public static void ScrollWindowDown(this IWebDriver driver)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(nameof(driver));
            }
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            Thread.Sleep(500);
        }
    }
}
