using Garcom.Test.Features.Support;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Garcom.Test.Features.StepDefintions
{
    [Binding]
    public class RegisterNewFeatureSteps
    {
        [Given("I am at the register new place page")]
        public void GivenIAmAtTheRegisterNewPlacePage()
        {
            SeleniumDriver.Driver.Open("/Garcom/places/new");
            var title = SeleniumDriver.Driver.GetTitle();
            Assert.That(title, Is.StringContaining("New"));
        }

        [Then("I should be at the all places page")]
        public void ShouldBeAtTheAllPlacesPage()
        {
            var title = SeleniumDriver.Driver.GetTitle();
            Assert.That(title, Is.StringContaining("Places"));
        }

        [When("I click submit")]
        public void WhenIClickSubmit()
        {
            SeleniumDriver.Driver.Click("submit");
        }
        [When("I fill in the name with (.*)")]
        public void WhenIFillOut(string name)
        {
            SeleniumDriver.Driver.Type("name", name);
        }

        [Then("I should see (.*)")]
        public void ShouldSee(string text)
        {
            var textIsPresent = SeleniumDriver.Driver.IsTextPresent(text);
            Assert.That(textIsPresent, Is.True);
        }
    }
}
