using System.Collections.Generic;

namespace Garcom.Models
{
    public class AllPlaces
    {
        private readonly MongoWrapper _mongoWrapper;

        public AllPlaces(MongoWrapper mongoWrapper) { _mongoWrapper = mongoWrapper; }

        public virtual IEnumerable<Place> All { get { return _mongoWrapper.Collection<Place>("places"); } }

        public virtual void Save(Place place) { _mongoWrapper.Save("places", place); }
    }
}