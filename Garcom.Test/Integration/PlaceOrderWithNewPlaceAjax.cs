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
            new Models.MongoDB().Delete("places");
            WebDriver.Initialize();
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.Quit();
        }

        [Test]
        public void AddNewPlaceWithAjax()
        {

            WebDriver.Driver.Navigate().GoToUrl(@"http://localhost/Garcom/Places");
           AllPlacesPage.SubmitNewPlaceWithAjax("Pizza");

           new WebDriverWait(WebDriver.Driver, new TimeSpan(0, 0, 10)).Until(driver => driver.FindElements(By.TagName("li")).Any());
            Assert.That(WebDriver.Driver.FindElements(By.TagName("li")).Any(e => e.Text.Contains("Pizza")),Is.True);
        }

        [Test]
        public void AddNewPlaceWithSubmit()
        {
            WebDriver.Driver.Navigate().GoToUrl(@"http://localhost/Garcom/Places/New");
            NewPlacesPage.SubmitNewPlace("Bauru");

            new WebDriverWait(WebDriver.Driver, new TimeSpan(0, 0, 10)).Until(driver => driver.FindElements(By.TagName("li")).Any());
            Assert.That(WebDriver.Driver.FindElements(By.TagName("li")).Any(e => e.Text.Contains("Bauru")), Is.True);
        }
     

    }
}
