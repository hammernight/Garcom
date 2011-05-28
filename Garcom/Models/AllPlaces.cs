using System.Collections.Generic;

namespace Garcom.Models
{
    public class AllPlaces
    {
        private readonly MongoDB _mongoDB;

        public AllPlaces(MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
        }

        public virtual IEnumerable<Place> All
        {
            get { return _mongoDB.Collection<Place>("places"); }
        }

        public virtual void Save(Place place)
        {
            _mongoDB.Save("places", place);
        }
    }
}