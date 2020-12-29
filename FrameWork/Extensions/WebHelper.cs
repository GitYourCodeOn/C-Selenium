using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Extensions
{
    public static class WebHelper
    {
        private static IWebElement safeWait(By by, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            IWebElement myElement = wait.Until<IWebElement>(driver =>
            {
                IWebElement byElement = driver.FindElement(by);
                return (byElement.Displayed || byElement.Enabled) ? byElement : null;
            });
            return myElement;
        }
        public static bool IsElementDisplayed(this By by, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            IWebElement myElement = wait.Until<IWebElement>(driver =>
            {
                IWebElement byElement = driver.FindElement(by);
                return (byElement.Displayed) ? byElement : null;
            });
            return true;
        }
        public static void EnterText(this String keys, By by, IWebDriver driver)
        {
            IWebElement element = safeWait(by, driver);
            IsElementDisplayed(by, driver);
            element.Clear();
            element.SendKeys(keys);
        }

        public static void Click(By by, IWebDriver driver)
        {
            var element = safeWait(by, driver);
            IsElementDisplayed(by, driver);
            element.Click();
        }
        public static void WindowScroll(IWebDriver driver, String horizontal, string vertical)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(" + horizontal + "," + vertical + ")");
        }

        public static void RangeSlider(By by, IWebDriver driver, int xAxis, int yAxis)
        {
            IWebElement element = safeWait(by, driver);
            Actions moveSlider = new Actions(driver);
            IAction action = moveSlider.DragAndDropToOffset(element, -xAxis, yAxis).Build();
            action.Perform();
        }
        public static void HoverOnElement(By by, IWebDriver driver)
        {
            IWebElement element = safeWait(by, driver);
            var mouseHover = new Actions(driver);
            mouseHover.MoveToElement(element).Perform();
        }

        public static void DropDownSelectByText(By by, String textValue, IWebDriver driver)
        {
            var element = safeWait(by, driver);
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(textValue);
        }

        public static void DropDownSelectByIndex(By by, int index, IWebDriver driver)
        {
            var element = safeWait(by, driver);
            var selectElement = new SelectElement(element);
            selectElement.SelectByIndex(index);
        }

        /* public static string GetSelectedDropDown(this IWebElement element)
         {
             SelectElement ddl = new SelectElement(element);
             return ddl.AllSelectedOptions.First().ToString();
         }

         public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
         {
             SelectElement ddl = new SelectElement(element);
             return ddl.AllSelectedOptions;
         }*/

        public static string GetLinkText(this IWebElement element)
        {
            return element.Text;
        }

    }
}
