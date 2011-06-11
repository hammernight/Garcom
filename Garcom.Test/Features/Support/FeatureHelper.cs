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

        [BeforeScenario]
        public static void StartScenario()
        {
            new Models.MongoWrapper().Delete("places");
        }

        [AfterFeature]
        public static void KillBrowser()
        {
            WebDriver.Driver.Quit();
        }
    }
}
