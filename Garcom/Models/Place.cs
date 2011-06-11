using MongoDB.Bson;

namespace Garcom.Models
{
    public class Place
    {
        public Place() { Menu = new Menu(); }

        public Place(string name) : this() { Name = name; }
        public string Name { get; set; }
        public BsonObjectId Id { get; set; }
        public Menu Menu { get; set; }
    }
}