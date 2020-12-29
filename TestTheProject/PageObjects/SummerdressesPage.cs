using FrameWork.Base;
using OpenQA.Selenium;

namespace TestTheProject.PageObjects
{
    public class SummerdressesPage : BasePage
    {
        public IWebDriver webDriver;
        public SummerdressesPage(IWebDriver driver)
        {
            webDriver = driver;
        }


    }
}


        