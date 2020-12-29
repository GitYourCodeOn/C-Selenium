using FrameWork.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestTheProject.PageObjects;

namespace UITests_Package.Steps
{
    [Binding]
    public sealed class BasketSteps : BasePage
    {

        public IWebDriver webdriver;

        public BasketSteps(IWebDriver driver)
        {
            webdriver = driver;
        }


        [Given(@"item has been added to cart")]
        public void GivenItemHasBeenAddedToCart()
        {
            CurrentPage = new Homepage(webdriver);
            CurrentPage = CurrentPage.As<Homepage>().clickAddtoCartBtn();
        }

        [Given(@"An item exists in my basket")]
        public void GivenAnItemExistsInMyBasket()
        {
            Assert.IsTrue(CurrentPage.As<MyBasketPage>().checkBasket());
            
        }

        [Given(@"Im able to see the delete button")]
        public void GivenImAbleToSeeTheDeleteButton()
        {
            Assert.IsTrue(CurrentPage.As<MyBasketPage>().checkTrashBtn());
        }

        [When(@"I select the delete button")]
        public void WhenISelectTheDeleteButton()
        {
            CurrentPage.As<MyBasketPage>().putInTrash();
        }

        [Then(@"the banner must display Your shopping Cart is Empty")]
        public void ThenTheBannerMustDisplayYourShoppingCartIsEmpty()
        {
            Assert.IsTrue(CurrentPage.As<MyBasketPage>().checkCartEmpty());
        }

    }

}
