using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using WooliesUI.PageClass;

namespace WooliesUI
{
    public class UnitTest1
    {
        [Test, Description ("Test that you can add two items to the cart and complete order")]
        public void PlaceOrderWithTwoItems()
        { 
            // Launch the browser 
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Constants.HomePageConstants.URL);
  
            // Perform actions for the test
            var homePage = new HomePage(driver);
            homePage.IncreaseQuantity();
            homePage.Checkout();
            homePage.SwitchToNewTab();
            Assert.IsTrue(homePage.OrderHasTwoItems(), "Order does not contain two items");
            homePage.ConfirmCheckout();
            homePage.ConfirmOrder();
            homePage.Login();
            homePage.ConfirmAddress();
            homePage.AcceptTerms();
            homePage.ConfirmDelivery();
            homePage.ClickPaymentMethod();
            homePage.SubmitOrder();
            //Assert order is placed
            Assert.IsTrue(homePage.OrderWasPlaced(), "Order was not placed");

            driver.Quit();
        }
    }
}