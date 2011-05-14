using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garcom.Test.Support;
using Selenium;
using TechTalk.SpecFlow;

namespace Garcom.Test
{
    [Binding]
    public class StepDefinition1
    {
        private ISelenium _driver;

        [Given("I am at the register new place page")]
        public void GivenIAmAtTheRegisterNewPlacePage()
        {
            SeleniumServer.Initialize();
            _driver = (ISelenium) ScenarioContext.Current["selenium"];
            ScenarioContext.Current.Pending();
        }

        [When("I click submit")]
        public void WhenIClickSubmit()
        {
            //TODO: implement act (action) logic

            ScenarioContext.Current.Pending();
        }
        [When("I fill in the name with (*)")]
        public void WhenIFillOut(string name)
        {
            //TODO 
        }

        [Then("I should see place created successfully")]
        public void ThenIShouldSeePlaceCreatedSuccessfully()
        {
            //TODO: implement assert (verification) logic

            ScenarioContext.Current.Pending();
        }
    }
}
