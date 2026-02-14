using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace PageObject.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver Create(Browser browser)
        {
            return browser switch
            {
                Browser.Chrome => new ChromeDriver(GetChromeOptions()),
                Browser.Firefox => new FirefoxDriver(GetFirefoxOptions()),
                _ => throw new ArgumentOutOfRangeException(nameof(browser), browser, null)
            };
        }

        private static ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            return options;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {
            var options = new FirefoxOptions();
            return options;
        }
    }
}