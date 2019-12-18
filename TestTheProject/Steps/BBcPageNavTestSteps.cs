using FrameWork.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TestTestFrame.Pages;


namespace TestTestFrame.Steps
{
    [Binding]
    public class BBcPageNavTestSteps : BasePage

    {

        [Given(@"I am on the BBc HomePage")]
        public void GivenIAmOnTheBBcHomePage()
        {
            CurrentPage = GetInstance<HomePage>();
            

        }

        [When(@"Inavigate to the Sports section")]
        public void WhenInavigateToTheSportsSection()
        {
            CurrentPage = CurrentPage
                 .As<HomePage>()
                 .clickSportsBtn();
        }

        [When(@"Click the homeepage button")]
        public void WhenClickTheHomeepageButton()
        {
            CurrentPage.As<SportPages>().clickHomePage();
        }

        [Then(@"I am navigated back to the homepage")]
        public void ThenIAmNavigatedBackToTheHomepage()
        {
            Console.WriteLine("Test");

            Assert.IsTrue(isGreater());
            bool isGreater()
            {
                return 6 > 5;
            }
        }
    }
}
