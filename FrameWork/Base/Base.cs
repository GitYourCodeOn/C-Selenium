using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Base
{
    public class Base
    {
        public BasePage CurrentPage
        {
            get;
            set;
        }


        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}
