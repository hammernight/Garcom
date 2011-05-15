using System.Web.Mvc;
using Garcom.Controllers;
using NUnit.Framework;

namespace Garcom.Test.Unit.Controllers
{
    [TestFixture]
    public class PlacesControllerSpec
    {
        private PlacesController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new PlacesController();
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
    }
    
}
