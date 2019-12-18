
using FrameWork.Base;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestTestFrame.Hooks
{
    [Binding]
    public class BrowserHooks : BasePage
    {
        [BeforeScenario(Order = 2)]
        public void startBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--headless");
            WebDriver.Driver = new ChromeDriver(option);
            WebDriver.Driver.Manage().Window.Maximize();
            WebDriver.Driver.Navigate().GoToUrl("https://www.bbc.co.uk/");

        }
        [AfterScenario(Order = 2)]
        public static void CloseBrowser()
        {
            WebDriver.Driver.Quit();
            

        }

        //[AfterTestRun]
        //public void EndBrowser()
        //{
        //    WebDriver.Driver.Close();
        //}
    }
}
