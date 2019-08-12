using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WizzAir.Utils.Extensions;

namespace WizzAir.Components.PageObjects
{
    public class SignInPage : BasePage
    {
        IWebDriver _driver;
        WebDriverWait _wait;
        public SignInPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
            _driver.WaitForDocumentReadyState();
        }

        public SignInPage VerifySignInPage()
        {
            string title = H2Title.Text.ToLower();
            StringAssert.Contains("sign in", title);
            return this;
        }

        private IWebElement H2Title => _wait.Until(ExpectedConditions.ElementIsVisible(SignInPageElements.Title));
        private IWebElement Email => _wait.Until(ExpectedConditions.ElementIsVisible(SignInPageElements.Email));
    }
}
