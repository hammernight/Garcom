using MongoDB.Bson;

namespace Garcom.Models
{
    public class Place
    {
        public Place() { }

        public Place(string name) { Name = name; }
        public string Name { get; set; }
        public BsonObjectId Id { get; set; }
    }
}