using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Garcom.Models
{
    public class MongoDB  : IDisposable
    {
        private MongoServer _server;
        private MongoDatabase _database;

        public MongoDB()
        {
        }

        public virtual void Dispose()
        {
            Disconnect();
        }

        private void Disconnect()
        {
            Server.Disconnect();
        }

        private MongoServer Server
        {
            get
            {
                return _server = _server ?? MongoServer.Create("mongodb://localhost");
            }
        }

        private MongoDatabase Database
        {
            get
            {
                return _database = _database ??  Server.GetDatabase("test");
            }
        }

        public virtual IEnumerable<T> Collection<T> (string collectionName)
        {
            using(var request = Server.RequestStart(Database))
            {
                var collection = Database.GetCollection<T>(collectionName);
                return collection.FindAll().AsEnumerable();
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