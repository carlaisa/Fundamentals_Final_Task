using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObject.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver {get;}
        protected WebDriverWait Wait {get;}

        protected BasePage(IWebDriver driver, int waitSeconds = 10)
        {
            Driver = driver ?? throw new ArgumentNullException(nameof(driver));
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitSeconds));
        }

        protected IWebElement WaitForVisible(By locator)
        {
            var element = Wait.Until(d =>
            {
                var e = d.FindElement(locator);
                return e.Displayed ? e : null;
            });

            if (element == null)
            {
                throw new WebDriverTimeoutException("Element was not visible");
            }

            return element;
        }

    }
}