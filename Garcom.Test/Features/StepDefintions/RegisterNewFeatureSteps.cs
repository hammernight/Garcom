using Garcom.Test.Features.Support;
using TechTalk.SpecFlow;

namespace Garcom.Test.Features.StepDefintions
{
    [Binding]
    public class RegisterNewFeatureSteps
    {
        [Given("I am at the register new place page")]
        public void GivenIAmAtTheRegisterNewPlacePage()
        {
            SeleniumDriver.Driver.Open("/places/new");
        }

        [When("I click submit")]
        public void WhenIClickSubmit()
        {
            SeleniumDriver.Driver.Click("submit");
        }
        [When("I fill in the name with (.*)")]
        public void WhenIFillOut(string name)
        {
            ScenarioContext.Current.Pending();
        }

        [Then("I should see place created successfully")]
        public void ThenIShouldSeePlaceCreatedSuccessfully()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
