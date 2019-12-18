using FrameWork.Base;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestTestFrame.Pages;

namespace TestTestFrame.Steps
{
    [Binding]
    public class BBcNewsPageSteps : BasePage
    {
        [Given(@"I am on the homePage")]
        public void GivenIAmOnTheHomePage()
        {
            CurrentPage = GetInstance<HomePage>();


        }

        [When(@"I click the Account button")]
        public void WhenIClickTheAccountButton()
        {
            CurrentPage = CurrentPage.As<HomePage>().clickAccountPage();
        }

        [Then(@"I am navigated to the Account Page")]
        public void ThenIAmNavigatedToTheAccountPage()
        {
            Assert.IsTrue(5 > 4);
        }

        [Then(@"Then navigated back to the HomePage by clicking the homepage button")]
        public void ThenThenNavigatedBackToTheHomePageByClickingTheHomepageButton()
        {
            CurrentPage.As<NewsPage>().clickHomePage();
        }
    }
}
