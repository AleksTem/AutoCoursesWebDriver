using OpenQA.Selenium;
using System;
using System.Linq;

namespace WD_Tests
{
    public static class CustomConditions
    {
        public static Func<IWebDriver, IWebElement> WizzElementBeEnabled(IWebElement element)
        {
            return (driver) =>
            {
                element = ElementIfVisible(element);
                try
                {
                    if (element != null && element.Enabled && !element.HasClass("loading"))
                    {
                        return element;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        private static IWebElement ElementIfVisible(IWebElement element)
        {
            return element.Displayed ? element : null;
        }

        private static bool HasClass(this IWebElement element, string className)
        {
            return element.GetAttribute("class").Split(' ').Contains(className);
        }
    }
}
