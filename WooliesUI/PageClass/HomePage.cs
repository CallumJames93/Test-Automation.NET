using System;
using System.Linq;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace WooliesUI.PageClass
{
    public class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = Constants.HomePageConstants.itemImageXPath)]
        [CacheLookup]
        public IWebElement addCartBtn { get; set; }

        [FindsBy(How = How.Id, Using = Constants.HomePageConstants.searchBarId)]
        [CacheLookup]
        public IWebElement searchBar { get; set; }

        [FindsBy(How = How.Id, Using = Constants.HomePageConstants.sizeDropdownId)]
        [CacheLookup]
        public IWebElement sizeDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = Constants.HomePageConstants.submitSearchClass)]
        [CacheLookup]
        public IWebElement submitSearch{ get; set; }

        [FindsBy(How = How.XPath, Using = Constants.HomePageConstants.womenTabXPath)]
        [CacheLookup]
        public IWebElement womenTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = Constants.HomePageConstants.quantityCssSelector)]
        [CacheLookup]
        public IWebElement quantityBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = Constants.HomePageConstants.checkoutCssSelector)]
        [CacheLookup]
        public IWebElement checkoutBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = Constants.HomePageConstants.confirmCheckoutCssSelector)]
        [CacheLookup]
        public IWebElement confirmCheckoutBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = Constants.HomePageConstants.confirmOrderCssSelector)]
        [CacheLookup]
        public IWebElement confirmOrderBtn { get; set; }

        [FindsBy(How = How.Id, Using = Constants.HomePageConstants.usernameFldID)]
        [CacheLookup]
        public IWebElement userNameFld { get; set; }

        [FindsBy(How = How.Id, Using = Constants.HomePageConstants.pwdFldId)]
        [CacheLookup]
        public IWebElement passwordFld { get; set; }

        [FindsBy(How = How.Id, Using = Constants.HomePageConstants.submitLoginBtnId)]
        [CacheLookup]
        public IWebElement submitLoginBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = Constants.HomePageConstants.quantityCssSelector)]
        [CacheLookup]
        public IWebElement quantityValue { get; set; }

        [FindsBy(How = How.CssSelector, Using = Constants.HomePageConstants.confirmAddressCssSelector)]
        [CacheLookup]
        public IWebElement confirmAddressBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = Constants.HomePageConstants.confirmDeliveryCssSelector)]
        [CacheLookup]
        public IWebElement confirmDeliveryBtn { get; set; }

        [FindsBy(How = How.Id, Using = Constants.HomePageConstants.termsId)]
        [CacheLookup]
        public IWebElement termsCheckBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = Constants.HomePageConstants.paymentBtnCssSelector)]
        [CacheLookup]
        public IWebElement paymentBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = Constants.HomePageConstants.submitOrderBtnCssSelector)]
        [CacheLookup]
        public IWebElement submitOrderBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = Constants.HomePageConstants.twitterCssSelector)]
        [CacheLookup]
        public IWebElement twitterBtn { get; set; }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ClickWomenTab()
        {
            womenTab.Click();
        }

        public void IncreaseQuantity()
        {
            quantityBtn.Click();
        }

        public void Checkout()
        {
            checkoutBtn.Click();
        }

        public void SwitchToNewTab()
        {
            driver.SwitchTo().ActiveElement();
        }

        public bool OrderHasTwoItems()
        {
            if(quantityValue.Text  == "2")
            {
                return true;
            }

            return false;
        }

        public void ConfirmCheckout()
        {
            confirmCheckoutBtn.Click();
        }

        public void ConfirmOrder()
        {
            confirmOrderBtn.Click();
        }

        public void Login()
        {
            userNameFld.SendKeys(Constants.HomePageConstants.username);
            passwordFld.SendKeys(Constants.HomePageConstants.password);
            submitLoginBtn.Submit();
        }

        public void ConfirmAddress()
        {
            confirmAddressBtn.Click();
        }

        public void AcceptTerms()
        {
            IWebElement terms = driver.FindElement(By.Id(Constants.HomePageConstants.termsId));
            terms.Click();
        }

        public void ConfirmDelivery()
        {
            confirmDeliveryBtn.Click();
        }

        public void ClickPaymentMethod()
        {
            paymentBtn.Click();
        }

        public void SubmitOrder()
        {
            submitOrderBtn.Click();
        }

        public bool OrderWasPlaced()
        {
            if (driver.Url.Contains(Constants.HomePageConstants.confirmOrderURL))
            {
                return true;
            }

            return false;
        }

        public void ClickTwitter()
        {
            twitterBtn.Click();
        }

        public void SwitchToNewWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            WaitTenSeconds();
        }

        public void WaitTenSeconds()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public bool TwitterWasLaunched()
        {
            if (driver.Url.Contains("twitter.com"))
            {
                return true;
            }
            return false;
        }

        public void SelectLargeSize()
        {
            SelectElement oSelect = new SelectElement(driver.FindElement(By.Id(Constants.HomePageConstants.sizeDropdownId)));
            oSelect.SelectByText("L");
            WaitTenSeconds();
        }

        public bool LargeItemWasSelected()
        {
            SelectElement oSelect = new SelectElement(driver.FindElement(By.Id(Constants.HomePageConstants.sizeDropdownId)));
            string actualItemSize = oSelect.SelectedOption.Text;

            if (actualItemSize == "L")
            {
                return true;
            }

            return false;
        }
    }
}
