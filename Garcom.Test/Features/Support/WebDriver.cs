using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace Garcom.Test.Features.Support
{
    public static class WebDriver
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                Initialize();
                return _driver;
            }
        }

        public static void Initialize()
        {
            _driver = _driver ?? new InternetExplorerDriver();
            _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));           
        }

    }
}