using System.Text;
using Selenium;
using TechTalk.SpecFlow;

namespace Garcom.Test.Features.Support
{
    public class SeleniumDriver
    {
        private static ISelenium _driver;
        
        public static ISelenium Driver
        {
            get
            {
                Initialize();
                return _driver;
            }
        }
        
        public static void Initialize()
        {
            if (_driver == null)
            {
                _driver = new DefaultSelenium("localhost", 4444, @"*firefox3 C:\Program Files (x86)\Firefox3\firefox.exe", "http://localhost:6666");
                _driver.Start();
            }

            ScenarioContext.Current["selenium"] = _driver;
            ScenarioContext.Current["selenium-errors"] = new StringBuilder();
            ScenarioContext.Current["StepCounter"] = 0;
        }
    }
}