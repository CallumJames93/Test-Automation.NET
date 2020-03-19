using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WooliesUI.PageClass;

namespace WooliesUI
{
    [TestFixture]
    class UnitTest1
    {
        IWebDriver driver = null;
        HomePage homePage = null;

        [OneTimeSetUp]
        public void CreateBrowser()
        {
            // Launch the browser 
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Constants.HomePageConstants.URL);
            homePage = new HomePage(driver);
        }

        [Test, Description ("Test that you can add two items to the cart and complete order")]
        public void PlaceOrderWithTwoItems()
        {
            //Complete actions for test
            homePage.IncreaseQuantity();
            homePage.Checkout();
            homePage.SwitchToNewTab();

            //Assert if two items are in the cart
            Assert.IsTrue(homePage.OrderHasTwoItems(), "Order does not contain two items");

            //Continue completing steps
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
        }

        [Test, Description("Test that you can launch Twitter")]
        public void TwitterBtnLaunchesTwitter()
        {
            //launch to twitter and switch to new window
            homePage.ClickTwitter();
            homePage.SwitchToNewWindow();
            //Assert that twitter loads in a new window
            Assert.IsTrue(homePage.TwitterWasLaunched(), "Twitter was not launched");
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            //Close browser once complete
            driver.Quit();
        }
    }
}