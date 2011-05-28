using Garcom.Test.Features.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Garcom.Test.Features.StepDefintions
{
    [Binding]
    public class RegisterNewFeatureSteps
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
            Assert.That(title, Is.StringContaining("New"));
        }

        [Then("I should be at the all places page")]
        public void ShouldBeAtTheAllPlacesPage()
        {
            var title = WebDriver.Driver.Title;
            Assert.That(title, Is.StringContaining("Places"));
        }

        [When("I click submit")]
        public void WhenIClickSubmit() { WebDriver.Driver.FindElement(By.Name("submit")).Click(); }

        [When("I fill in the name with (.*)")]
        public void WhenIFillOut(string name) { WebDriver.Driver.FindElement(By.Id("name")).SendKeys(name); }

        [Then("I should see (.*)")]
        public void ShouldSee(string text)
        {
            var body = WebDriver.Driver.FindElement(By.TagName("body")).Text;
            Assert.That(body, Is.StringContaining(text));
        }
    }
}