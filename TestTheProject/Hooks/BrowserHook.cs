using BoDi;
using FrameWork.Base;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly ScenarioContext scenarioContext;
        private static string pathString;
        public BrowserHooks(IObjectContainer _oBjectContainer, ScenarioContext _scenarioContext)
        {
            oBjectContainer = _oBjectContainer;
            scenarioContext = _scenarioContext;
        }

        [BeforeScenario(Order = 2)]
        public void startBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());            
            ChromeOptions option = new ChromeOptions();
            //option.AddArgument("--headless");
            webDriver = new ChromeDriver(option);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("http://automationpractice.com/");
            oBjectContainer.RegisterInstanceAs<IWebDriver>(webDriver);

        }

        [AfterScenario(Order = 2)]
        public void CloseBrowser()
        {
            webDriver.Quit();

        }

        [AfterStep(Order = 3)]
        public void CaptureFailedStepScreenshot()
        {
            if (scenarioContext.TestError != null)
            {
                var solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
                var file = Path.Combine(solutionDir, "../..", " Fail Screenshots");
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
                Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                ss.SaveAsFile(path + "/screenshot.png", ScreenshotImageFormat.Png);

            }

        }



    }
}
