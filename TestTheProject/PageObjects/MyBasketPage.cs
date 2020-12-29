using Framework.Extensions;
using FrameWork.Base;
using OpenQA.Selenium;

namespace TestTheProject.PageObjects
{
    public class MyBasketPage : BasePage
    {
        public IWebDriver webDriver;
        public MyBasketPage(IWebDriver driver)
        {
            webDriver = driver;
        }

        private By basketItem = By.XPath("//*[contains(@class,'cart_item')]");
       

        private By trashBtn = By.XPath("//*[contains(@class,'icon-trash')]");


        private By emptyCart = By.XPath("//*[contains(text(),'Your shopping cart is empty')]");

        public bool checkBasket()
        {
            return WebHelper.IsElementDisplayed(basketItem, webDriver);
        }

        public bool checkTrashBtn()
        {
            return  WebHelper.IsElementDisplayed(trashBtn, webDriver);
        }

        public MyBasketPage putInTrash()
        {
            WebHelper.Click(trashBtn, webDriver);
            
            return new MyBasketPage(webDriver);
        }

        public bool checkCartEmpty()
        {
            
            return WebHelper.IsElementDisplayed(emptyCart, webDriver);
        }      

    }
}
