using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Norm;

namespace Garcom.Models
{
    public class Test
    {
        public void TestingMongo ()
        {
            using (var db = Mongo.Create("mongodb://localhost/test"))
            {
                var tests = db.GetCollection<Test>();
                tests.Insert(new Test{Name = "my test"});
            }
        }

        public string Name { get; set; }
        public ObjectId _id { get; set; }
    }
}