using System;
using OpenQA.Selenium;


namespace Garcom.Test.Features.Support
{
    public abstract class BasePage
    {
        public IWebDriver CurrentPage { get; set; }

        public virtual string CurrentPageTitle {get {throw new NotImplementedException(string.Format("'{0}' Is not the 'Correct Current page'", GetType().FullName));}}

        public virtual Uri Url(params string[] args)
        {
            throw new NotImplementedException(string.Format("'{0} does not have a 'Url' property.",GetType().FullName));
        }

        public abstract bool Valid();
    }
}
