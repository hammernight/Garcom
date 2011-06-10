using System;
using Garcom.Test.Features.Support;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Garcom.Test.Pages
{
    class NewPlacesPage : BasePage
    {
        public override Uri Url(params string[] args)
        {
            return new Uri(@"http://localhost/Garcom/Places/New");
        }

        public override string CurrentPageTitle { get { return "New Places"; } }

        public override bool Valid()
        {
            Assert.That(CurrentPage.Title, Is.EqualTo(CurrentPageTitle));
            return true;
        }


        //PageObjects

        private static IWebElement PlacesName { get { return WebDriver.Driver.FindElement(By.Id("name")); } }
        private static IWebElement SubmitButton { get { return WebDriver.Driver.FindElement(By.Id("submit")); } }

        //Actions
        public static void SubmitNewPlace(string newPlaceName)
        {
            PlacesName.SendKeys(newPlaceName);
            SubmitButton.Click();
        }

    }
}
