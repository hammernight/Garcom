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
                Initialize(false);
                return _driver;
            }
        }

        public static void Initialize(bool force=true)
        {
            if (force)
            {
                _driver = new InternetExplorerDriver();               
            }
            else
            {
                _driver = _driver ?? new InternetExplorerDriver();              
            }
            _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));           
        }

        public static void Quit()
        {
            _driver.Close();
            _driver.Quit();
        }

    }
}