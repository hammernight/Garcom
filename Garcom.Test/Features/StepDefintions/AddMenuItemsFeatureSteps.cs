using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garcom.Models;
using Garcom.Test.Features.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Garcom.Test.Features.StepDefintions
{
    [Binding]
    public class AddMenuItemsFeatureSteps : FeatureHelper
    {
        [Given(@"""(.*)"" is an existent place")]
        public void IsExistentPlace(string placeName)
        {
            var place = new Place(placeName);
            new MongoWrapper().Save("places", place);
        }
        
	    [When(@"I click on the name of ""(.*)""")]
        public void ClickOnTheNameOf(string placeName)
        {
            WebDriver.Driver.FindElement(By.LinkText(placeName)).Click();  
        }

	    [Then(@"I should be at ""(.*)"" page")]
        public void BeAtThePlacesPage(string placeName) 
        { 
            Assert.That(WebDriver.Driver.Title, Is.StringContaining(placeName));
        }
    }
}