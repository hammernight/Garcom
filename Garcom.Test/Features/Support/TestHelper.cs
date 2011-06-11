using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Garcom.Test.Pages;
using OpenQA.Selenium.Support.UI;

namespace Garcom.Test.Features.Support
{
    class TestHelper
    {
        public static void GetReady()
        {
            new Models.MongoWrapper().Delete("places");
            WebDriver.Initialize();
        }

        public static void ShutDown()
        {
            WebDriver.Quit();
        }

        public static void GoHere(string pageUrl)
        {
            WebDriver.Driver.Navigate().GoToUrl(pageUrl);
        }

        public static void WaitForMe(string tagname)
        {
            new WebDriverWait(WebDriver.Driver, new TimeSpan(0, 0, 10)).Until(driver => driver.FindElements(By.TagName(tagname)).Any());
        }
    }
}
