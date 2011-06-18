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

        [Given(@"I am at ""(.*)"" page")]
        public void PlacesPage(string placeName)
        {
            var place = FeatureContext.Current["place"] as Place;
            WebDriver.Driver.Navigate().GoToUrl("http://localhost/Garcom/places/place/" + place.Id.Value);
        }

        [Given(@"""(.*)"" sells awesome pasteis")]
        public void SellsAwesomePasteis(string placeName)
        {
            var place = new Place(placeName);
            new MongoWrapper().Save("places", place);
            FeatureContext.Current["place"] = place;
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