using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Garcom.Controllers;
using NUnit.Framework;

namespace Garcom.Test.Unit.Controllers
{
    [TestFixture]
    public class HomeControllerSpec
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
    }
    
}
