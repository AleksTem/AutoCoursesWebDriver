using OpenQA.Selenium;

namespace WD_Tests.WizzAir
{
    public static class Airport
    {
        public static By Departure => By.Id("search-departure-station");
        public static By Arrival => By.Id("search-arrival-station");
        public static By ConfirmLocation => By.ClassName("locations-container__location__name");
    }
}
