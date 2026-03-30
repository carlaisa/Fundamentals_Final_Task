using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObject.Utils;


namespace PageObject.Pages;

public class Login :  BasePage
{
    private static string Url { get; } = "https://www.saucedemo.com";

    public Login(IWebDriver driver) : base(driver) {}

    private By UsernameField => By.Id("user-name");
    private By PasswordField => By.Id("password");
    private By LoginButton => By.Id("login-button");
    private By ErrorContainer => By.CssSelector(".error-message-container");
    private By HomeTitle => By.CssSelector(".app_logo");

    //private readonly IWebDriver driver;

    //public Login(IWebDriver driver) => 
    //    this.driver = driver ?? throw new ArgumentException(nameof(driver));

    public Login Open()
    {
        Driver.Navigate().GoToUrl(Url);
        return this;
    }

    public void EnterUsername(string username)
    {
        var user = WaitForVisible(UsernameField);
        user.Click();
        user.SendKeys(username);
        //this.UsernameField.Click();
        //this.UsernameField.SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        var pass = WaitForVisible(PasswordField);
        pass.Click();
        pass.SendKeys(password);
        //this.PasswordField.Click();
        //this.PasswordField.SendKeys(password);
    }

    public void ClearUsername()
    {
        var user = WaitForVisible(UsernameField);
        user.ClearAndWaitEmpty(Driver, TimeSpan.FromSeconds(10));
         //this.UsernameField.ClearAndWaitEmpty(driver, TimeSpan.FromSeconds(10));
    }
   

    public void ClearPassword() 
    {
        var pass = WaitForVisible(PasswordField);
        pass.ClearAndWaitEmpty(Driver, TimeSpan.FromSeconds(10));
        //=> this.PasswordField.ClearAndWaitEmpty(driver, TimeSpan.FromSeconds(10));
    }
    public void ClickLogin() 
    {
       WaitForVisible(LoginButton).Click();
       // => this.LoginButton.Click();
    }

    public string GetErrorMessageText()
    {
        return WaitForVisible(ErrorContainer).Text;
    }

    public string GetTitleHomePage()
    {
        return WaitForVisible(HomeTitle).Text;
    }

}


