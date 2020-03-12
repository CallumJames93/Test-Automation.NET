using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using WooliesUI.PageClass;

namespace WooliesUI
{
    public class Tests
    {
        [Test, Description ("Test that you can add two items to the cart and complete order")]
        public void AddtoCart()
        { 
            // Launch the browser 
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
  
            // Perform actions for the test
            var homePage = new HomePage(driver);
            homePage.ClickWomenTab();

            //Assert that two items can be checked out
            //Assert.Pass();

            driver.Quit();
        }
    }
}