using FrameWork.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestTheProject.PageObjects;
using UITests_Package.Utils;

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
            var accountReg = table.CreateInstance <RegisterationData>();

            CurrentPage.As<AccountsPage>().completeRegisteration(accountReg.FirstName,accountReg.LastName,
                accountReg.Password, accountReg.FirstName, accountReg.LastName, accountReg.Company, accountReg.Address, accountReg.City,
                accountReg.PostCode, accountReg.HomePhone, accountReg.Mobilephone, accountReg.AddressAlias)
                .clickRegisterAccount();
        }

        [Then(@"an account will be created successfully")]
        public void ThenAnAccountWillBeCreatedSuccessfully()
        {
            Assert.IsTrue(CurrentPage.As<AccountsPage>().assertRegisterationComplete());
        }


    }
}
