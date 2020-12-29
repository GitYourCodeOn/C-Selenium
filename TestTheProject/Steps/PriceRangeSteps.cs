using FrameWork.Base;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestTheProject.PageObjects;

namespace UITests_Package.Steps
{
    [Binding]
    public sealed class PriceRangeSteps : BasePage
    {

        public IWebDriver webdriver;

        public PriceRangeSteps(IWebDriver driver)
        {
            webdriver = driver;
        }

        [Given(@"I have navigated to the dresses page")]
        public void GivenIHaveNavigatedToTheDressesPage()
        {
            CurrentPage = new Homepage(webdriver);
            CurrentPage = CurrentPage.As<Homepage>().ClickDressesBtn();
        }


        [When(@"I select the price range to be between \$(.*)-\$(.*)")]
        public void WhenISelectThePriceRangeToBeBetween_(int price1, int price2)
        {
            CurrentPage.As<DressesPage>().selectMyBudget();
        }

        [Then(@"I should see results that match my budget in the search results")]
        public void ThenIShouldSeeResultsThatMatchMyBudgetInTheSearchResults()
        {
            CurrentPage.As<DressesPage>().AssertPriceRange();
        }

    }
}
