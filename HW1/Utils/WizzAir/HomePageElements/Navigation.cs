using OpenQA.Selenium;

namespace WD_Tests.WizzAir
{
    public static class Navigation
    {
        public static By SearchBtn => By.CssSelector(".flight-search__panel__fieldset--cta-btn > button");
    }
}
