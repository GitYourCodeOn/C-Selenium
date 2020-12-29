using FrameWork.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestTheProject.PageObjects;

namespace UITests_Package.Steps
{
    [Binding]
    public sealed class ProdCategorySteps: BasePage
    {

        public IWebDriver webdriver;

        public ProdCategorySteps(IWebDriver driver)
        {
            webdriver = driver;
        }

        [Given(@"I am on the automationpractice homepage")]
        public void GivenIAmOnTheAutomationpracticeHomepage()
        {
            CurrentPage = new Homepage(webdriver);
            
        }

        [Given(@"I Hover over the WOMAN category and assert subnavigation options")]
        public void GivenIHoverOverTheWOMANCategoryAndAssertSubnavigationOptions()
        {
            Assert.IsTrue(CurrentPage.As<Homepage>().hoverOnWomanBtn());
        }

        [When(@"I click the Summer dresses button on WOMAN sub-navigation")]
        public void WhenIClickTheSummerDressesButtonOnWOMANSub_Navigation()
        {
            CurrentPage.As<Homepage>().clickSummerDresses();
        }

        [Then(@"Only summer items are displayed inside the search results")]
        public void ThenOnlySummerItemsAreDisplayedInsideTheSearchResults()
        {
            Assert.IsTrue(CurrentPage.As<Homepage>().assertSummerDressesPage());
        }

    }
}
