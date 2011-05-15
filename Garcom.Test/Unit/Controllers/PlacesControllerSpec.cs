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
        private PlacesController _controller;
        private Mock<AllPlaces> _allPlaces;

        [SetUp]
        public void Setup()
        {
            _allPlaces = new Mock<AllPlaces>(MockBehavior.Loose);
            _controller = new PlacesController(_allPlaces.Object);
        }

        [Test]
        public void ItShouldProvideAFormToRegisterANewPlace()
        {
            var result = _controller.New();
            Assert.That(result, Is.InstanceOf(typeof (ViewResult)));
        }

        [Test]
        public void ItShouldListAllThePlaces()
        {
            var result = _controller.Index();
            Assert.That(result, Is.InstanceOf(typeof(ViewResult)));
        }

        [Test]
        public void WhenCreatingItShouldRedirectToThePlacesList()
        {
            var place = new Place("some place");
            var result = _controller.Create(place) as RedirectToRouteResult;
            Assert.That(result,Is.Not.Null);
            Assert.That(result.RouteValues["controller"], Is.EqualTo("places"));
            Assert.That(result.RouteValues["action"], Is.EqualTo("index"));
        }

        [Test]
        public void WhenCreatingItShouldDelegateToTheRepository()
        {
            var place = new Place("some place");
            _controller.Create(place);
            _allPlaces.Verify(it => it.Save(place));
        }
    }
}
