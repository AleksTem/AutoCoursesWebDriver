using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace WebDriver_CSharp_Example
{


    [TestFixture]
    public class Chrome_Sample_test
    {
        private IWebDriver driver;
        public string homeURL;

        [SetUp]
        public void SetupTest()
        {
            homeURL = "http://SauceLabs.com";
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }

        [Test(Description = "Check SauceLabs Homepage for Login Link")]
        public void Login_is_on_home_page()
        {
            homeURL = "https://www.SauceLabs.com";
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver,System.TimeSpan.FromSeconds(15));
            wait.Until(driver =>driver.FindElement(By.XPath("//a[@href='/beta/login']")));
            IWebElement element = driver.FindElement(By.XPath("//a[@href='/beta/login']"));
            Assert.AreEqual("Sign In", element.GetAttribute("text"));
        }
    }
}