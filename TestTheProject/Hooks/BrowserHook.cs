
using BoDi;
using FrameWork.Base;
using OpenQA.Selenium;
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
        private readonly IObjectContainer oBjectContainer;

        private IWebDriver webDriver;

        public BrowserHooks(IObjectContainer _oBjectContainer)
        {
            oBjectContainer = _oBjectContainer;
        }

        [BeforeScenario(Order = 2)]
        public void startBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--headless");
            webDriver = new ChromeDriver(option);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://www.bbc.co.uk/");
            oBjectContainer.RegisterInstanceAs<IWebDriver>(webDriver);

        }
        [AfterScenario(Order = 2)]
        public  void CloseBrowser()
        {
            webDriver.Quit();
            

        }

        //[AfterTestRun]
        //public void EndBrowser()
        //{
        //    WebDriver.Driver.Close();
        //}
    }
}
