using FrameWork.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTestFrame.Pages
{
    public class SportPages : BasePage
    {
        public IWebDriver webDriver;
        public SportPages(IWebDriver driver)
        {
            webDriver = driver;
        }

        private IWebElement homeBtn => webDriver.FindElement(By.XPath("//*[contains(@class," +
            "'orb-nav-section orb-nav-blocks')]//*[contains(text(),'Homepage')]"));

        



        public HomePage clickHomePage()
        {
            //CustomWaits.implicitWait(5);
            homeBtn.Click();
            return new HomePage(webDriver);
        }
    }


}
