using System;
using MongoDB.Driver;

namespace Garcom.Models
{
    public class AllPlaces
    {
        private readonly MongoDB _mongoDB;

        public AllPlaces(MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
        }

        public virtual void Save(Place place)
        {
        }
    }
}