using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Selenium;
using TechTalk.SpecFlow;

namespace Garcom.Test.Features.Support
{
    public class WebDriver
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
            if (_driver == null)
            {

                _driver = new ChromeDriver();
                    
                    //new DefaultSelenium("localhost", 4444,
                    //                          @"*firefox3 C:\Program Files (x86)\Firefox3\firefox.exe",
                    //                          "http://localhost/Garcom/");
                
            }

            ScenarioContext.Current["selenium"] = _driver;
            ScenarioContext.Current["selenium-errors"] = new StringBuilder();
            ScenarioContext.Current["StepCounter"] = 0;
        }
    }
}