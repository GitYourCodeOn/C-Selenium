
using FrameWork.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTestFrame.Pages
{
    class NewsPage : BasePage
    {
        
        private IWebElement homeBtn => WebDriver.Driver.FindElement(By.XPath("//*[contains(@class," +
           "'orb-nav-section orb-nav-blocks')]//*[contains(text(),'Homepage')]"));

        public HomePage clickHomePage()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver.Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => WebDriver.Driver.FindElement(By.XPath("//*[contains(@class," +
           "'orb-nav-section orb-nav-blocks')]//*[contains(text(),'Homepage')]")).Displayed);
            homeBtn.Click();
            return GetInstance<HomePage>();
        }
    }
}
