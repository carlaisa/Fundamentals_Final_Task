using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.Pages;
using PageObject.Drivers;

namespace PageObject.Tests;

[TestFixture(Browser.Chrome)]
[TestFixture(Browser.Firefox)]
public class LoginTests
{
    private readonly Browser _browser;
    private IWebDriver? driver;

    private IWebDriver Driver =>
        driver ?? throw new InvalidOperationException("WebDriver is not initialized.");

    public LoginTests(Browser browser) => _browser = browser;

    [SetUp]
    public void SetUp()
    {
        driver = DriverFactory.Create(_browser);
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void Login_Form_With_Empty_Credentials()
    {
        var loginPage = new Login(Driver);
        loginPage.Open();

        loginPage.EnterUsername("any_username");
        loginPage.EnterPassword("password123");
        loginPage.ClearUsername();
        loginPage.ClearPassword();

        loginPage.ClickLogin();

        Assert.That(loginPage.GetErrorMessageText(), Does.Contain("Username is required"));
    }

    [Test]
    public void Login_Form_With_Credentials_By_Passing_Username()
    {
        var loginPage = new Login(Driver);
        loginPage.Open();

        loginPage.EnterUsername("any_username");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClearPassword();

        loginPage.ClickLogin();

        Assert.That(loginPage.GetErrorMessageText(), Does.Contain("Password is required"));
    }

    [Test]
    public void Login_Form_With_Credentials_By_Passing_Username_And_Password()
    {
        var loginPage = new Login(Driver);
        loginPage.Open();

        loginPage.EnterUsername("standard_user");
        loginPage.EnterPassword("secret_sauce");

        loginPage.ClickLogin();

        Assert.That(loginPage.GetTitleHomePage(), Is.EqualTo("Swag Labs")); 

    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver = null;
    }

}
