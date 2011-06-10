using System;
using Garcom.Test.Features.Support;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Garcom.Test.Pages
{
    class AllPlacesPage : BasePage
    {
        public override Uri Url(params string[] args)
        {
            return new Uri(@"http://localhost/Garcom/Places");
        }

        public override string CurrentPageTitle { get { return "All Places"; } }

        public override bool Valid()
        {
            Assert.That(CurrentPage.Title, Is.EqualTo(CurrentPageTitle));
            return true;
        }


        //PageObjects

        private static IWebElement PlacesName { get { return WebDriver.Driver.FindElement(By.Id("name")); } }
        private static IWebElement AjaxButton { get { return WebDriver.Driver.FindElement(By.Id("create_place_with_ajax")); } }

        //Actions
        public static void SubmitNewPlaceWithAjax(string newPlaceName)
        {
            PlacesName.SendKeys(newPlaceName);
            AjaxButton.Click();
        }
    }
}
