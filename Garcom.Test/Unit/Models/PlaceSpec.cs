using Garcom.Models;
using NUnit.Framework;

namespace Garcom.Test.Unit.Models
{
    [TestFixture]
    public class PlaceSpec
    {
        [Test]
        public void ShouldHaveAMenu()
        {
            var place = new Place("Georges Pasteis");
            Assert.That(place.Menu, Is.Not.Null);
        }
    }
}