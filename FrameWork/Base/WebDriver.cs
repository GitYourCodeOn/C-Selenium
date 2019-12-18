using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Base
{
    public static class WebDriver
    {

        public static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                return _driver;
            }

            set
            {
                _driver = value;
            }
        }
    }
}
