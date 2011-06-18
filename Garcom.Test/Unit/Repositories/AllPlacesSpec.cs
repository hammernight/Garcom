using Garcom.Models;
using Moq;
using NUnit.Framework;

namespace Garcom.Test.Unit.Repositories
{
    [TestFixture]
    public class AllPlacesSpec
    {
        [SetUp]
        public void Setup()
        {
            _mongoDB = new Mock<Garcom.Models.MongoWrapper>(MockBehavior.Loose);
            _allPlaces = new AllPlaces(_mongoDB.Object);
        }

        private AllPlaces _allPlaces;
        private Mock<Garcom.Models.MongoWrapper> _mongoDB;

        [Test]
        public void WhenSavingItShouldDelegateToMongoAbstraction()
        {
            var place = new Place("fooBarBazQuux");

            _allPlaces.Save(place);

            _mongoDB.Verify(it => it.Save("places", place));
        }

        [Test]
        public void ShouldDelegateFindByIdToTheWrapper()
        {
            var placeId = "42";
            var expectedPlace = new Place();
            _mongoDB.Setup(it => it.FindById<Place>("places", placeId)).Returns(expectedPlace);
            var actualPlace = _allPlaces.FindById(placeId);

            Assert.That(actualPlace, Is.SameAs(expectedPlace));
        }
    }
}