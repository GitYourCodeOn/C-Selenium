using FrameWork.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestTheProject.PageObjects;

namespace TestTheProject.Steps
{
    [Binding]
    public sealed class AccountSteps : BasePage
    {

        public IWebDriver webdriver;

        public AccountSteps(IWebDriver driver)
        {
            webdriver = driver;
        }


        [Given(@"I navigate to the Sign in page")]
        public void GivenINavigateToTheSignInPage()
        {
            CurrentPage = new Homepage(webdriver);
            CurrentPage = CurrentPage.As<Homepage>().clickSignInBtn();
        }

      

        [Given(@"I enter '(.*)' email address on registeration")]
        public void GivenIEnterEmailAddressOnRegisteration(string email)
        {
            CurrentPage.As<AccountsPage>().enterRegisterationEmail(email);
        }


        [When(@"I select create account")]
        public void WhenISelectCreateAccount()
        {
            CurrentPage.As<AccountsPage>().clickCreateAccountBtn();
        }

        [Given(@"I select create account")]
        public void GivenISelectCreateAccount()
        {
            CurrentPage.As<AccountsPage>().clickCreateAccountBtn();
        }

        [Given(@"I select create accouqnt")]
        

        [Then(@"I get a valid green response")]
        public void ThenIGetAValidGreenResponse()
        {
            Assert.IsTrue(CurrentPage.As<AccountsPage>().assertvalidEmail());
        }

        [Given(@"I enter an incorrect email address on registeration")]
        public void GivenIEnterAnIncorrectEmailAddressOnRegisteration()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click away from the")]
        public void WhenIClickAwayFromThe()
        {
            ScenarioContext.Current.Pending();
        }
     

        [Then(@"I get an invalid data response")]
        public void ThenIGetAnInvalidDataResponse()
        {
            Assert.IsTrue(CurrentPage.As<AccountsPage>().assertInvalidEmail());
            Assert.IsTrue(CurrentPage.As<AccountsPage>().assertInvalidEmailTick());         


        }

        [When(@"I click register on the Create An Account Page without populating required fields")]
        public void WhenIClickRegisterOnTheCreateAnAccountPageWithoutPopulatingRequiredFields()
        {
            CurrentPage.As<AccountsPage>().clickRegisterAccount();
        }

        [Then(@"an invalid data banner will appear")]
        public void ThenAnInvalidDataBannerWillAppear()
        {
            Assert.IsTrue(CurrentPage.As<AccountsPage>().invalidDataBannerDisplayed());
        }

        [When(@"I populate all required fields and click register")]
        public void WhenIPopulateAllRequiredFieldsAndClickRegister(Table table)            
        {
            //Slightly easier to manage and scalable when using a foreach loop
            // Example below, if we decided to include more rows on the table, we can iterate using index
            // E.g row[Firstname][1] for the second row 
            /*foreach (var row in table.Rows)
            {
                CurrentPage.As<AccountsPage>().completeRegisteration(row["FirstName"], row["LastName"],
                row["Password"], row["FirstName"], row["LastName"], row["Company"], row["Address"], row["City"],
                row["PostCode"], row["HomePhone"], row["Mobilephone"], row["AddressAlias"])
                .clickRegisterAccount();
            }*/

            //This is for a vertical table which is key, value pairing and more suitable
            var dict = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dict.Add(row[0], row[1]);
            }

            CurrentPage.As<AccountsPage>().completeRegisteration(dict["FirstName"], dict["LastName"],
               dict["Password"], dict["FirstName"], dict["LastName"], dict["Company"], dict["Address"], dict["City"],
               dict["PostCode"], dict["HomePhone"], dict["Mobilephone"], dict["AddressAlias"])
               .clickRegisterAccount();
        }

        [Then(@"an account will be created successfully")]
        public void ThenAnAccountWillBeCreatedSuccessfully()
        {
            Assert.IsTrue(CurrentPage.As<AccountsPage>().assertRegisterationComplete());
        }


    }
}
