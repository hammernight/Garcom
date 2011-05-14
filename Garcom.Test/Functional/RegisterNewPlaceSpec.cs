using System.Text;
using NUnit.Framework;
using Selenium;

namespace Garcom.Test.Functional
{
    [TestFixture]
    public class RegisterNewPlaceSpec
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetUpTests()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [Test]
        public void RegisterNewPlace()
        {
            selenium.Open("/Places/New");
            selenium.Click("submit");
            selenium.WaitForPageToLoad("3000");
        }


    }
}
