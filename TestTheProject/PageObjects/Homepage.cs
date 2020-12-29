using Framework.Extensions;
using FrameWork.Base;
using OpenQA.Selenium;

namespace TestTheProject.PageObjects
{
    public class Homepage : BasePage
    {

        public IWebDriver webDriver;
        public Homepage(IWebDriver driver)
        {
            webDriver = driver;
        }

        private By SignInBtn => By.XPath("//*[contains(text(),'Sign in')]");
        private By WomenBtn => By.XPath("//*[contains(text(),'Women')]");
        private By addToCartBtn => By.XPath("  //*[contains(text(),'Add to cart')]");
        private By closeItemCartWindowBtn => By.XPath("//*[@title= 'Close window']");
        private By shoppingCartBtn => By.XPath("//*[@title= 'View my shopping cart']");
        private By dressesBtn => By.XPath("//header/div[3]/div[1]/div[1]/div[6]/ul[1]/li[2]/a[1]");

        private By summerDresses = By.XPath("//header/div[3]/div[1]/div[1]/div[6]/ul[1]/li[1]/ul[1]/li[2]/ul[1]/li[3]/a[1]");

        private By summerDressesPage = By.XPath("//span[contains(text(),'Summer Dresses')]");

        private By ourStoresBtn = By.XPath("//a[contains(text(),'Our stores')]");

        private By fadeShort = By.XPath("//*[contains(text(),'Faded Short')]");

        private By womenCat = By.XPath("//*[contains(text(),'Women')]");


        public AccountsPage clickSignInBtn()
        {
            WebHelper.Click(SignInBtn, webDriver);

            return new AccountsPage(webDriver);
        }

        public MyBasketPage clickAddtoCartBtn()
        {

            WebHelper.WindowScroll(webDriver, "0", "1000");
            WebHelper.HoverOnElement(fadeShort, webDriver);
            WebHelper.Click(addToCartBtn, webDriver);
            WebHelper.Click(closeItemCartWindowBtn, webDriver);
            WebHelper.Click(shoppingCartBtn, webDriver);

            return new MyBasketPage(webDriver);
        }

        public bool hoverOnWomanBtn()
        {
            WebHelper.HoverOnElement(womenCat, webDriver);

            return WebHelper.IsElementDisplayed(summerDresses, webDriver);
        }

        public SummerdressesPage clickSummerDresses()
        {
            WebHelper.Click(summerDresses, webDriver);

            return new SummerdressesPage(webDriver);
        }

        public DressesPage ClickDressesBtn()
        {
            WebHelper.Click(dressesBtn, webDriver);

            return new DressesPage(webDriver);
        }

        public bool assertSummerDressesPage()
        {
            return WebHelper.IsElementDisplayed(summerDressesPage, webDriver);
        }

        public OurStoresPages clickOurStores()
        {
            WebHelper.Click(ourStoresBtn, webDriver);

            return new OurStoresPages(webDriver);
        }

    }
}
