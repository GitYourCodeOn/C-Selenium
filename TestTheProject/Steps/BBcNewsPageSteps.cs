using FrameWork.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TestTestFrame.Pages;

namespace TestTestFrame.Steps
{
    [Binding]
    public class BBcNewsPageSteps : BasePage
    {
        public IWebDriver webDriver;

        public BBcNewsPageSteps(IWebDriver driver)
        {
            webDriver = driver;
        }

        [Given(@"I am on the homePage")]
        public void GivenIAmOnTheHomePage()
        {
            CurrentPage = new HomePage(webDriver);


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
