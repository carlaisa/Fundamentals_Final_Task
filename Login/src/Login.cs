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

    private IWebElement UsernameField => driver.FindElement(By.Id("user-name"));
    private IWebElement PasswordField => driver.FindElement(By.Id("password"));
    private IWebElement LoginButton => driver.FindElement(By.Id("login-button"));

    public void EnterUsername(string username)
    {
        UsernameField.Click();
        UsernameField.SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        PasswordField.Click();
        PasswordField.SendKeys(password);
    }

    public void ClearUsername() => UsernameField.ClearAndWaitEmpty(driver, TimeSpan.FromSeconds(10));

    public void ClearPassword() => PasswordField.ClearAndWaitEmpty(driver, TimeSpan.FromSeconds(10));
    public void ClickLogin() => LoginButton.Click();

    public string GetErroMessageText()
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        var error = wait.Until(d =>
        {
            var e = d.FindElement(By.CssSelector(".error-message-container"));
            return e.Displayed ? e : null;
        });

        return error.Text;       
    }

    public string GetTitleHomePage()
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        var title = wait.Until(d =>
        {
            var e = d.FindElement(By.CssSelector(".app_logo"));
            return e.Displayed ? e : null;
        });

        return title.Text;
    }

}


