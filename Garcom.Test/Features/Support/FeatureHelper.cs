using TechTalk.SpecFlow;

namespace Garcom.Test.Features.Support
{
    [Binding]
    public class FeatureHelper
    {
        [BeforeFeature]
        public static void StartDriver()
        {
            WebDriver.Initialize();
        }

        [AfterScenario]
        public static void StartScenario()
        {
            new Models.MongoDB().Delete("places");
        }

        [AfterFeature]
        public static void KillBrowser()
        {
            WebDriver.Driver.Close();
        }
    }
}
