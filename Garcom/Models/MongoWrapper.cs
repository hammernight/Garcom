using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Garcom.Models
{
    public class MongoWrapper : IDisposable
    {
        private MongoDatabase _database;
        private MongoServer _server;

        private MongoServer Server { get { return _server = _server ?? CreateServer(); } }

        private MongoDatabase Database { get { return _database = _database ?? CreateDatabase(); } }

        public virtual void Dispose() { Disconnect(); }

        private MongoServer CreateServer() { return MongoServer.Create("mongodb://localhost"); }
        private MongoDatabase CreateDatabase() { return Server.GetDatabase("test"); }

        private void Disconnect() { Server.Disconnect(); }

        public virtual IEnumerable<T> Collection<T>(string collectionName)
        {
            using (var request = Server.RequestStart(Database))
            {
                var collection = Database.GetCollection<T>(collectionName);
                return collection.FindAll().AsEnumerable();
            }
        }

       public virtual void Delete(string collectionName)
       {
           try
           {
               using (var request = Server.RequestStart(Database))
               {
                   var collection = Database.GetCollection(collectionName);
                   collection.Drop();
               }
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
           }
       }
        
        public virtual T FindById<T>(string collectionName, string id) where T : class
        {
            using(var request = Server.RequestStart(Database))
            {
                var collection = Database.GetCollection<T>(collectionName);
                var entity = collection.FindOne(Query.EQ("_id", new BsonObjectId(id)));
                return entity as T;
            }
        }


        public virtual T Save<T>(string collectionName, T entity)
        {
            using (var request = Server.RequestStart(Database))
            {
                var collection = Database.GetCollection<T>(collectionName);
                dynamic x = entity;
                x.Id = x.Id ?? ObjectId.GenerateNewId();
                collection.Save(entity);
                return entity;
            }
        }
    }
}
