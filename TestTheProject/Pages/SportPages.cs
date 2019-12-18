using FrameWork.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTestFrame.Pages
{
    class SportPages : BasePage
    {
        private IWebElement homeBtn => WebDriver.Driver.FindElement(By.XPath("//*[contains(@class," +
            "'orb-nav-section orb-nav-blocks')]//*[contains(text(),'Homepage')]"));



        public HomePage clickHomePage()
        {
            CustomWaits.implicitWait(5);
            homeBtn.Click();
            return GetInstance<HomePage>();
        }
    }


}
