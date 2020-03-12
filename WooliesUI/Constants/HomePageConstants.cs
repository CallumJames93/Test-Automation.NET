using System;
namespace WooliesUI.Constants
{
    public class HomePageConstants
    {
        public const string itemImageXPath = "//*[@id='homefeatured']/li[1]/div/div[1]/div/a[1]";
        public const string searchBarId = "search_query_top";
        public const string submitSearchClass = "//*[@id='searchbox']/button";
        public const string womenTabXPath = "//*[@id='block_top_menu]/ul/li[1]/a";

        public const string URL = "http://automationpractice.com/index.php?id_product=3&controller=product";
        public const string quantityCssSelector = "#quantity_wanted_p > a.btn.btn-default.button-plus.product_quantity_up > span > i";
        public const string checkoutCssSelector = "#add_to_cart > button > span";
        public const string confirmCheckoutCssSelector = "#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a > span > i";
        public const string quantityFldCssSelector = "#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > h2 > span.ajax_cart_product_txt_s.unvisible > span";
        public const string confirmOrderCssSelector = "#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium > span > i";

        public const string usernameFldID = "email";
        public const string pwdFldId = "passwd";
        public const string submitLoginBtnId = "SubmitLogin";

        public const string username = "callum.testing@test.com";
        public const string password = "Memtest_4697";

        public const string confirmAddressCssSelector = "#center_column > form > p > button > span > i";

        public const string termsId = "cgv";
        public const string confirmDeliveryCssSelector = "#form > p > button > span > i";


        public const string paymentBtnCssSelector = "#HOOK_PAYMENT > div:nth-child(1) > div > p > a";

        public const string submitOrderBtnCssSelector = "#cart_navigation > button > span > i";

        public const string confirmOrderURL = "controller=order-confirmation&id_cart=";


    }
}
