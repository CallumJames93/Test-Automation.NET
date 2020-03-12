using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;

namespace WooliesUI.TestBase
{
    public class TestBase
    {
        public static IWebDriver driver;

        public static void CreateBrowser()
        {
            
        }

        public static void TearDown()
        {
            driver.Close();
        }
    }
}
