using System;
using System.Linq;
using Garcom.Test.Features.Support;
using Garcom.Test.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Garcom.Test.Integration 
{
    [TestFixture]
    class PlaceOrderWithNewPlaceAjax
    {
        [SetUp]
        public void Setup()
        {
            TestHelper.GetReady();
        }

        [TearDown]
        public void TearDown()
        {
            TestHelper.ShutDown();
        }

        [Test]
        public void AddNewPlaceWithAjax()
        {

            TestHelper.GoHere(@"http://localhost/Garcom/Places");
           AllPlacesPage.SubmitNewPlaceWithAjax("Pizza");

           TestHelper.WaitForMe("li");
            Assert.That(WebDriver.Driver.FindElements(By.TagName("li")).Any(e => e.Text.Contains("Pizza")),Is.True);
        }

        [Test]
        public void AddNewPlaceWithSubmit()
        {
            TestHelper.GoHere(@"http://localhost/Garcom/Places/New");
            NewPlacesPage.SubmitNewPlace("Bauru");

            TestHelper.WaitForMe("li");
            Assert.That(WebDriver.Driver.FindElements(By.TagName("li")).Any(e => e.Text.Contains("Bauru")), Is.True);
        }
     

    }
}
