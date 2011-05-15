using System;
using MongoDB.Driver;

namespace Garcom.Models
{
    public class AllPlaces
    {
        private readonly MongoDatabase _dataBase;

        public AllPlaces(MongoDatabase dataBase)
        {
            _dataBase = dataBase;
        }

        public virtual void Save(Place place)
        {
        }
    }
}