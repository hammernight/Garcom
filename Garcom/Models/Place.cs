using MongoDB.Bson;

namespace Garcom.Models
{
    public class Place
    {
        public string Name { get; set; }
        public BsonObjectId Id { get; set; }

        public Place()
        {
            
        }

        public Place(string name)
        {
            Name = name;
        }
    }
}