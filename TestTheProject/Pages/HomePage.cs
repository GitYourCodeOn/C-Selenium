using FrameWork.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;


namespace TestTestFrame.Pages
{
    public class HomePage : BasePage
    {
        public IWebDriver webDriver;
        public HomePage(IWebDriver driver)
        {
            webDriver = driver;
        }

        private IWebElement newsBtn => webDriver.FindElement(By.XPath("//*[@class = " +
            "'orb-nav-section orb-nav-links orb-nav-focus']//a[text()='News']"));
        private IWebElement sportBtn => webDriver.FindElement(By.XPath("//*[@class = " +
            "'orb-nav-section orb-nav-links orb-nav-focus']//a[text()='Sport']"));
        public SportPages clickSportsBtn()
        {

            //CustomWaits.implicitWait(10);
            sportBtn.Click();
            return new SportPages(webDriver);
        }

        public NewsPage clickAccountPage()
        {
           // CustomWaits.implicitWait(10);
            newsBtn.Click();
            return new NewsPage(webDriver);
        }


    }
}
