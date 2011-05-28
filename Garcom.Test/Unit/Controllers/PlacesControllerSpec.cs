using System.Collections.Generic;
using System.Web.Mvc;
using Garcom.Controllers;
using Garcom.Models;
using Moq;
using NUnit.Framework;

namespace Garcom.Test.Unit.Controllers
{
    [TestFixture]
    public class PlacesControllerSpec
    {
        [SetUp]
        public void Setup()
        {
            _allPlaces = new Mock<AllPlaces>(MockBehavior.Loose, null);
            _controller = new PlacesController(_allPlaces.Object);
        }

        private PlacesController _controller;
        private Mock<AllPlaces> _allPlaces;

        [Test]
        [Ignore]
        public void DB()
        {
            var place = new Place("test 3");
            var mongo = new Models.MongoDB();
            mongo.Save("places", place);
            place.Name = "test 5";
            mongo.Save("places", place);
            mongo.Save("places", new Place("test 4"));
        }

        [Test]
        public void ItShouldListAllThePlaces()
        {
            var allPlaces = new List<Place> {new Place("a"), new Place("b")};
            _allPlaces.SetupGet(it => it.All).Returns(allPlaces);

            var result = _controller.Index();

            Assert.That(result, Is.InstanceOf(typeof (ViewResult)));
            Assert.That(result.Model, Is.SameAs(allPlaces));
        }

        [Test]
        public void ItShouldListAllThePlacesAsAPartial()
        {
            var allPlaces = new List<Place> {new Place("a"), new Place("b")};
            _allPlaces.SetupGet(it => it.All).Returns(allPlaces);

            var result = _controller.ListOfPlaces() as PartialViewResult;

            Assert.That(result, Is.InstanceOf(typeof (PartialViewResult)));
            Assert.That(result.Model, Is.SameAs(allPlaces));
            Assert.That(result.ViewName, Is.EqualTo("_listOfPlaces"));
        }

        [Test]
        public void ItShouldProvideAFormToRegisterANewPlace()
        {
            var result = _controller.New();
            Assert.That(result, Is.InstanceOf(typeof (ViewResult)));
        }

        [Test]
        public void WhenCreatingAsAjaxItShouldDelegateToTheRespository()
        {
            var place = new Place("some place");
            _controller.CreateAjax(place);
            _allPlaces.Verify(it => it.Save(place));
        }

        [Test]
        public void WhenCreatingItShouldDelegateToTheRepository()
        {
            var place = new Place("some place");
            _controller.Create(place);
            _allPlaces.Verify(it => it.Save(place));
        }

        [Test]
        public void WhenCreatingItShouldRedirectToThePlacesList()
        {
            var place = new Place("some place");
            var result = _controller.Create(place) as RedirectToRouteResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.RouteValues["controller"], Is.EqualTo("places"));
            Assert.That(result.RouteValues["action"], Is.EqualTo("index"));
        }
    }
}