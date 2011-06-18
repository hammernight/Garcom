using System;
using System.Linq;
using System.Threading;
using Garcom.Test.Features.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Garcom.Test.Features.StepDefintions
{
    [Binding]
    public class RegisterNewPlaceFeatureSteps : FeatureHelper
    {
        [Given("I am at the register new place page")]
        public void GivenIAmAtTheRegisterNewPlacePage()
        {
            WebDriver.Driver.Navigate().GoToUrl("http://localhost/Garcom/places/new");
            var title = WebDriver.Driver.Title;
            Assert.That(title, Is.StringContaining("New"));
        }

        [Given("I am at the all places page")]
        public void GivenIAmAtTheAllPlaces()
        {
            WebDriver.Driver.Navigate().GoToUrl("http://localhost/Garcom/places");
            var title = WebDriver.Driver.Title;
            Assert.That(title, Is.StringContaining("All Places"));
        }

        [When(@"I fill in ""(.*)"" with ""(.*)""")]
        public void WhenIFillInNameWithUsinaDosPasteis(string fieldId, string fieldValue)
        {
            WebDriver.Driver.FindElement(By.Id(fieldId)).SendKeys(fieldValue);
        }

        [When(@"I click on ""(.*)""")]
        public void WhenIClickOnSubmit(string buttonId)
        {
            WebDriver.Driver.FindElement(By.Id(buttonId)).Click();
        }

        [Then(@"I should see a link to ""(.*)""")]
        public void ThenIShouldSeeALinkTo(string content)
        {
            new WebDriverWait(WebDriver.Driver, new TimeSpan(0, 0, 10)).Until(driver => driver.FindElements(By.TagName("li")).Any());
            Assert.That(WebDriver.Driver.FindElements(By.LinkText(content)), Is.Not.Empty);
        }


    }
}