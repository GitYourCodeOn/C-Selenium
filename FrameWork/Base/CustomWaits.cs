using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Base
{
    public  class CustomWaits
    {
        private IWebDriver webDriver;

        public CustomWaits(IWebDriver driver)
        {
            webDriver = driver;
        }

        public void implicitWait(int time)
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }
    }
}
