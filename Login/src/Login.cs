using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PageObject.Utils;


namespace PageObject.Pages;

public class Login
{
    private static string Url { get; } = "https://www.saucedemo.com";

    private readonly IWebDriver driver;

    public Login(IWebDriver driver) => 
        this.driver = driver ?? throw new ArgumentException(nameof(driver));

    public Login Open()
    {
        driver.Navigate().GoToUrl(Url);
        return this;
    }

    private IWebElement UsernameField => this.driver.FindElement(By.Id("user-name"));
    private IWebElement PasswordField => this.driver.FindElement(By.Id("password"));
    private IWebElement LoginButton => this.driver.FindElement(By.Id("login-button"));

    public void EnterUsername(string username)
    {
        this.UsernameField.Click();
        this.UsernameField.SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        this.PasswordField.Click();
        this.PasswordField.SendKeys(password);
    }

    public void ClearUsername() => this.UsernameField.ClearAndWaitEmpty(driver, TimeSpan.FromSeconds(10));

    public void ClearPassword() => this.PasswordField.ClearAndWaitEmpty(driver, TimeSpan.FromSeconds(10));
    public void ClickLogin() => this.LoginButton.Click();

    public string GetErrorMessageText()
    {
        var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));

        var error = wait.Until(d =>
        {
            var e = d.FindElement(By.CssSelector(".error-message-container"));
            return e.Displayed ? e : null;
        });


        return error?.Text
            ?? throw new WebDriverTimeoutException("Error message was not visible.");
    }

    public string GetTitleHomePage()
    {
        var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));

        var title = wait.Until(d =>
        {
            var e = d.FindElement(By.CssSelector(".app_logo"));
            return e.Displayed ? e : null;
        });

        return title?.Text
            ?? throw new WebDriverTimeoutException("Title was not visible.");
    }

}


