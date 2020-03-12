using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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

        [FindsBy(How = How.XPath, Using = Constants.HomePageConstants.submitSearchClass)]
        [CacheLookup]
        public IWebElement submitSearch{ get; set; }

        [FindsBy(How = How.XPath, Using = Constants.HomePageConstants.womenTabXPath)]
        [CacheLookup]
        public IWebElement womenTab { get; set; }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ClickWomenTab()
        {
            womenTab.Click();
        }
    }
}
