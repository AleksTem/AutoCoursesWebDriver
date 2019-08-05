using OpenQA.Selenium;

namespace WD_Tests.WizzAir
{
    public static class Outbound
    {
        private static By ParentDiv => By.Id("outbound-fare-selector");

        public static By Address => By.CssSelector(".flight-select__flight__title-container__title");

    }
}
