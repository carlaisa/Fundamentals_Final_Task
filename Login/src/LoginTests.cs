using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.Pages;

namespace PageObject.Tests;

[TestFixture]
public class LoginTests
{
    private IWebDriver driver;

    [SetUp]
    public void SetUp()
    {
        var options = new ChromeOptions();
        options.AddArgument("--incognito");

        driver = new ChromeDriver(options);
    }

    [Test]
    public void Login_Form_With_Empty_Credentials()
    {
        var loginPage = new Login(driver);
        loginPage.Open();

        loginPage.EnterUsername("any_username");
        loginPage.EnterPassword("password123");
        loginPage.ClearUsername();
        loginPage.ClearPassword();

        loginPage.ClickLogin();

        Assert.That(loginPage.GetErroMessageText(), Does.Contain("Username is required"));
    }

    [Test]
    public void Login_Form_With_Credentials_By_Passing_Username()
    {
        var loginPage = new Login(driver);
        loginPage.Open();

        loginPage.EnterUsername("any_username");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClearPassword();

        loginPage.ClickLogin();

        Assert.That(loginPage.GetErroMessageText(), Does.Contain("Password is required"));
    }

    [Test]
    public void Login_Form_With_Credentials_By_Passing_Username_And_Password()
    {
        var loginPage = new Login(driver);
        loginPage.Open();

        loginPage.EnterUsername("standard_user");
        loginPage.EnterPassword("secret_sauce");

        loginPage.ClickLogin();

        Assert.That(loginPage.GetTitleHomePage(), Is.EqualTo("Swag Labs")); 

    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

}
