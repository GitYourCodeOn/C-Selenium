using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Base
{
    public static class CustomWaits
    {
        public static void implicitWait(int time)
        {
            WebDriver.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }
    }
}
