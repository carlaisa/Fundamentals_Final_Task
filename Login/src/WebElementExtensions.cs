using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V114.IndexedDB;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObject.Utils
{
    public static class WebElementExtensions
    {
        public static void ClearAndWaitEmpty(this IWebElement element, IWebDriver driver, TimeSpan timeout)
        {
            element.Click();

            var actions = new Actions(driver);
            actions
                .KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .SendKeys(Keys.Backspace)
                .Perform();

            var wait = new WebDriverWait(driver, timeout);
            wait.Until(d => string.IsNullOrEmpty(element.GetAttribute("value")));
        }
    }
}