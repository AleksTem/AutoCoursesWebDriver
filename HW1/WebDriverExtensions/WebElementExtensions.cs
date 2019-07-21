using OpenQA.Selenium;

namespace HW1
{
    public static class WebElementExtensions
    {
        public static bool ElementIsPresent(this IWebDriver driver, By by)
        {
            var present = false;
            driver.Manage().Timeouts().ImplicitWait = Config.NoWait;
            try
            {
                present = driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
            }
            driver.Manage().Timeouts().ImplicitWait = Config.ImplicitWait;
            return present;
        }

    }
}
