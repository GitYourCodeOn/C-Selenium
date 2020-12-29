using Framework.Extensions;
using FrameWork.Base;
using OpenQA.Selenium;

namespace TestTheProject.PageObjects
{
    public class DressesPage : BasePage

    {
        public IWebDriver webDriver;
        public DressesPage(IWebDriver driver)
        {
            webDriver = driver;
        }

        private By priceRangeslider = By.XPath("//body/div[@id='page']/div[2]/div[1]/div[3]/div[1]/div[2]/div[1]/form[1]/div[1]/div[10]/ul[1]/div[1]/div[1]/a[2]");

        private By preferedPricePoint = By.XPath("//*[@style ='left: 38%')]");

        private By pricePoint = By.XPath("//*[contains(text(),'$16.00 - $30.06')]");

     
        public DressesPage selectMyBudget()
        {            
            WebHelper.WindowScroll(webDriver, "0", "1000");
            WebHelper.Click(priceRangeslider, webDriver);
            WebHelper.RangeSlider(priceRangeslider, webDriver, 150, 0);
            return new DressesPage(webDriver);
        }

        public bool AssertPriceRange()
        {            
            return WebHelper.IsElementDisplayed(pricePoint, webDriver);
        }

    }
}
