using FrameWork.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;


namespace TestTestFrame.Pages
{
    class HomePage : BasePage
    {



        private IWebElement newsBtn => WebDriver.Driver.FindElement(By.XPath("//*[@class = " +
            "'orb-nav-section orb-nav-links orb-nav-focus']//a[text()='News']"));
        private IWebElement sportBtn => WebDriver.Driver.FindElement(By.XPath("//*[@class = " +
            "'orb-nav-section orb-nav-links orb-nav-focus']//a[text()='Sport']"));
        public SportPages clickSportsBtn()
        {

            CustomWaits.implicitWait(10);
            sportBtn.Click();
            return GetInstance<SportPages>();
        }

        public NewsPage clickAccountPage()
        {
            CustomWaits.implicitWait(10);
            newsBtn.Click();
            return GetInstance<NewsPage>();
        }


    }
}
