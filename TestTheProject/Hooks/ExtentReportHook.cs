using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using FrameWork.Base;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

//[assembly:Parallelizable(ParallelScope.Fixtures)]
namespace TestTestFrame.Hooks
{
    [Binding]
    public class ExtentReportHook : BasePage
    {
        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;
        private ExtentTest currentScenarioName;

        public ExtentReportHook(ScenarioContext _scenarioContext, FeatureContext _featureContext)
        {
            scenarioContext = _scenarioContext;
            featureContext = _featureContext;
        }

        private static ExtentTest featureName;
        private static AventStack.ExtentReports.ExtentReports extent;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            var file = Path.Combine(solutionDir, "../..", "UI Test Reports", "ExtentReports", "ExtentReport.html");
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            var htmlReporter = new ExtentHtmlReporter(path);
            // instantiate a new Aventstack object 
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeScenario]
        public void Initialize()
        {
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            currentScenarioName = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    currentScenarioName.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    currentScenarioName.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    currentScenarioName.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    currentScenarioName.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    currentScenarioName.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                else if (stepType == "When")
                    currentScenarioName.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                else if (stepType == "Then")
                    currentScenarioName.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
            }
            else if (scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    currentScenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    currentScenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    currentScenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
    }
}
