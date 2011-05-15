using Garcom.Models;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;

namespace Garcom.Test.Unit.Repositories
{
    [TestFixture]
    public class AllPlacesSpec
    {
        [Test]
        public void WhenSavingItShouldDelegateToMongoDriver()
        {
            
            var mongoServer = new Mock<MongoServer>(MockBehavior.Loose, new MongoServerSettings());
            var dataBase = new Mock<MongoDatabase>(MockBehavior.Loose, mongoServer,
                                                   new MongoDatabaseSettings("", new MongoCredentials("", ""),
                                                                             SafeMode.True, true));
            var george = new Place("Georges Pasteis");
            var places = new AllPlaces(dataBase.Object);
            var collection = new Mock<MongoCollection<Place>>(MockBehavior.Loose, null as MongoDatabase, null);

            dataBase.Setup(it => it.GetCollection<Place>("places")).Returns(collection.Object);
            places.Save(george);
            collection.Verify(it => it.Insert(george));
        }
    }
}