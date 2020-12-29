using Framework.Extensions;
using FrameWork.Base;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace TestTheProject.PageObjects
{
    public class AccountsPage : BasePage
    {
        public IWebDriver webDriver;
        public AccountsPage(IWebDriver driver)
        {
            webDriver = driver;
        }


        private By registerEmailField = By.XPath("//*[@name ='email_create']");

        private By createAccountBtn = By.XPath("//*[@id= 'SubmitCreate']");

        private By validEmailTick = By.XPath(" //*[@class ='form-group form-ok']");

        private By invalidEmailTick = By.XPath(" //*[@class ='form-group form-error']");  
        
        private By invalidEmailResponse = By.XPath("//li[contains(text(),'Invalid email address')]");

        private By RegisterAccountBtn = By.XPath("//*[contains(text(),'Register')]");

        private By invalidDataBanner = By.XPath("//*[contains(@class,'alert alert-danger')]");

        private By firstName = By.XPath("//input[contains(@id,'customer_firstname')]");

        private By lastNameField = By.XPath("//input[contains(@id,'customer_lastname')]");

        private By dobDays = By.XPath("//div[contains(@class,'selector')]//*[@id = 'days']");
        
        private By dobMonths = By.XPath("//*[@name= 'months']");
        
        private By dobYears = By.XPath("//*[@name= 'years']");
       
        private By addressFirstName = By.XPath("//*[@id= 'firstname']");

        private By addressLastName = By.XPath("//*[@id= 'lastname']");

        private By companyField = By.XPath("//*[@id= 'company']");               

        private By stateDropDown = By.XPath("//*[@name= 'id_state']");       

        private By phoneNumber = By.XPath("//*[@name= 'phone']");        

        private By phoneNumberMobile = By.XPath("//input[@id='phone_mobile']");

        private By aliasField = By.XPath("//*[@name= 'alias']");
       
        private By passwordField = By.XPath("//input[@type = 'password']");

        private By cityField = By.XPath("//input[@name = 'city']");

        private By postcodeField = By.XPath("//input[@name = 'postcode']");  

        private By accountRegistered = By.XPath("//*[contains(text(),'Welcome to your account')]");

        private By address1 = By.XPath("//*[@name ='address1']");



        public AccountsPage enterRegisterationEmail(String email)
        {           
            
            WebHelper.EnterText(email + RandomString(2), registerEmailField, webDriver);
            return new AccountsPage(webDriver);
        }

        public void clickRegisterAccount()
        {            
            WebHelper.WindowScroll(webDriver, "0", "1500");
            WebHelper.Click(RegisterAccountBtn, webDriver);                        
        }

        public AccountsPage completeRegisteration(String FirstName, String LastName, string Password,
            String AddressFirstName, String AddressLastName, String company, String Address,
            String AddressCity, String AddressPostCode, String Phone, String MobilePhone, String aliasAddress)
        {            
            
            WebHelper.EnterText(FirstName, firstName, webDriver);
            WebHelper.EnterText(LastName, lastNameField, webDriver);
            WebHelper.EnterText(Password, passwordField, webDriver);            
            selectDob();           
            WebHelper.EnterText(AddressFirstName, addressFirstName, webDriver);
            WebHelper.EnterText(AddressLastName, addressLastName, webDriver);
            WebHelper.EnterText(company, companyField, webDriver);
            WebHelper.EnterText(Address, address1, webDriver);
            WebHelper.EnterText(AddressCity, cityField, webDriver);
            WebHelper.EnterText(AddressPostCode, postcodeField, webDriver);
            WebHelper.WindowScroll(webDriver, "0", "500");
            selectState();           
            WebHelper.EnterText(Phone, phoneNumber, webDriver);
            WebHelper.EnterText(MobilePhone, phoneNumberMobile, webDriver);
            WebHelper.EnterText(aliasAddress, aliasField, webDriver);
            return new AccountsPage(webDriver);
        }       
        public AccountsPage selectState()
        {           
            WebHelper.DropDownSelectByIndex(stateDropDown, 18, webDriver);
            return new AccountsPage(webDriver);
        }       
        public AccountsPage selectDob()
        {
            WebHelper.WindowScroll(webDriver, "0", "500");                    
            WebHelper.DropDownSelectByIndex(dobDays, 18, webDriver);
            WebHelper.DropDownSelectByIndex(dobMonths, 12, webDriver);
            WebHelper.DropDownSelectByIndex(dobYears, 28, webDriver);           
            return new AccountsPage(webDriver);
        }

        public bool invalidDataBannerDisplayed()
        {
            WebHelper.WindowScroll(webDriver, "1500", "0");
            return webDriver.FindElement(invalidDataBanner).Displayed;                   
        }
        public void clickCreateAccountBtn()
        {
            WebHelper.Click(createAccountBtn, webDriver);
        }

        public bool assertvalidEmail()
        {
            return WebHelper.IsElementDisplayed(validEmailTick, webDriver);                       
        }

        public bool assertInvalidEmailTick()
        {
            return WebHelper.IsElementDisplayed(invalidEmailTick, webDriver);                      
        }

        public bool assertInvalidEmail()
        {            
            return WebHelper.IsElementDisplayed(invalidEmailResponse, webDriver);      
           
        }
        public bool assertRegisterationComplete()
        {
            return WebHelper.IsElementDisplayed(accountRegistered, webDriver);
        }

        private static string RandomString(int length)
        {
            Random random = new Random();

            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[random.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }
    }

}

