using Garcom.Models;
using Moq;
using NUnit.Framework;

namespace Garcom.Test.Unit.Repositories
{
    [TestFixture]
    public class AllPlacesSpec
    {
        private AllPlaces _allPlaces;
        private Mock<Models.MongoDB> _mongoDB;

        [SetUp]
        public void Setup()
        {
            _mongoDB = new Mock<Models.MongoDB>(MockBehavior.Loose);
            _allPlaces = new AllPlaces(_mongoDB.Object);
        }

        [Test]
        public void WhenSavingItShouldDelegateToMongoAbstraction()
        {
            var place = new Place("fooBarBazQuux");
            
            _allPlaces.Save(place);

            _mongoDB.Verify(it => it.Save("places", place));
        }
    }
}