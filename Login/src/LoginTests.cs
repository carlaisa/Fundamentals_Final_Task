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
        driver = new ChromeDriver();
    }

    [Test]
    public void Login_From_With_Empty_Credentials()
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

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

}
