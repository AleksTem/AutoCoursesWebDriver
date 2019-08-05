using OpenQA.Selenium;

namespace WD_Tests
{
    public static class WebElementExtensions
    {
        public static bool ElementIsPresent(this IWebDriver driver, By by)
        {
            var present = false;
            driver.Manage().Timeouts().ImplicitWait = DriverConfig.NoWait;
            try
            {
                present = driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
            }
            driver.Manage().Timeouts().ImplicitWait = DriverConfig.ImplicitWait;
            return present;
        }

    }
}
