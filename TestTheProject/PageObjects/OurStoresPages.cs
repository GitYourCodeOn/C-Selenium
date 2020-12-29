using Framework.Extensions;
using FrameWork.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace TestTheProject.PageObjects
{
    public class OurStoresPages : BasePage
    {
        public IWebDriver webDriver;
        public OurStoresPages(IWebDriver driver)
        {
            webDriver = driver;
        }

        private By addressInputField = By.XPath("//input[@id='addressInput']");

        private By searchBtn = By.XPath("//body/div[@id='page']/div[2]/div[1]/div[3]/div[1]/div[2]/div[3]/button[1]/span[1]");

        public OurStoresPages scrollOnMap()
        {
            return new OurStoresPages(webDriver);
        }
        public void inputAddress(String address)
        {
            WebHelper.EnterText(address, addressInputField, webDriver);
            WebHelper.Click(searchBtn, webDriver);
        }

        public void screenShotResults()
        {
            var solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            var file = Path.Combine(solutionDir, "../..", "OurStore Images");
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);            
            ss.SaveAsFile(path+"/Image.png", ScreenshotImageFormat.Png);
        }
      
    }
}
