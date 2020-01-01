
using FrameWork.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTestFrame.Pages
{
    public class NewsPage : BasePage
    {
        private IWebDriver webDriver;
        public NewsPage(IWebDriver driver)
        {
            webDriver = driver;
        }

        private IWebElement homeBtn => webDriver.FindElement(By.XPath("//*[contains(@class," +
           "'orb-nav-section orb-nav-blocks')]//*[contains(text(),'Homepage')]"));

        public HomePage clickHomePage()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => webDriver.FindElement(By.XPath("//*[contains(@class," +
           "'orb-nav-section orb-nav-blocks')]//*[contains(text(),'Homepage')]")).Displayed);
            homeBtn.Click();
            return new HomePage(webDriver);
        }
    }
}
