using FrameWork.Base;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestTheProject.PageObjects;

namespace UITests_Package.Steps
{
    [Binding]
    public sealed class OurStoresSteps : BasePage
    {

        public IWebDriver webdriver;

        public OurStoresSteps(IWebDriver driver)
        {
            webdriver = driver;
        }


        [Given(@"I navigate to the Our Stores web page")]
        public void GivenINavigateToTheOurStoresWebPage()
        {
            CurrentPage = new Homepage(webdriver);
            CurrentPage = CurrentPage.As<Homepage>().clickOurStores();
        }

        [Given(@"I scroll through the map")]
        public void GivenIScrollThroughTheMap()
        {
             CurrentPage.As<OurStoresPages>().scrollOnMap();
        }

       

        [Then(@"I'm able to find stores nearby for me to take a screenshot")]
        public void ThenIMAbleToFindStoresNearbyForMeToTakeAScreenshot()
        {
            CurrentPage.As<OurStoresPages>().screenShotResults();
        }

        [When(@"I search '(.*)'")]
        public void WhenISearch(string address)
        {
            CurrentPage.As<OurStoresPages>().inputAddress(address);
        }


    }
}
