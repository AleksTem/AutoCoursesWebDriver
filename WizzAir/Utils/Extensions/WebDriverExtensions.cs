using OpenQA.Selenium;
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

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);
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

    }
}
