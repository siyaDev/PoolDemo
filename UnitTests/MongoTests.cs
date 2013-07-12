using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using MongoDBPool.Models;
using NUnit.Framework;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace UnitTests
{
    public class MongoHelper
    {
        private static MongoHelper _instance;

        public static MongoHelper Instance
        {
            get { return _instance ?? (_instance = new MongoHelper()); }
        }

        private MongoServer _server;

        public MongoDatabase Database
        {
            get { return Server.GetDatabase("TournamentDabase"); }
        }

        private MongoServer Server
        {
            get
            {
                if (_server == null || _server.State != MongoServerState.Connected)
                {
                    _server = CreateServer();
                }
                return _server;
            }
        }


        private MongoServer CreateServer()
        {
            string connectionString = "mongodb://127.0.0.1";
            var server = MongoServer.Create(connectionString);
            return server;
        }
    }

    public class Entity
    {
        public ObjectId Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
    }

    [TestFixture]
    public class MongoTests
    {
        [Test]
        public void TestConnection()
        {
            MongoCollection<Entity> collection = MongoHelper.Instance.Database.GetCollection<Entity>("Entities");
            //Assert.That(collection, Is.Null);
        }

        [Test]
        public void WriteReadDbTest()
        {
            string key = Guid.NewGuid().ToString();

            var entity = new Entity
                             {
                                 Key = key,
                                 Name = "test",
                                 Number = 123,
                             };

            MongoCollection<Entity> collection = MongoHelper.Instance.Database.GetCollection<Entity>("Entities");
            collection.Insert(entity);

            Entity fetchedEntity = collection.FindOne(Query.EQ("Key", key));
            Assert.That(fetchedEntity, !Is.Null);
            Assert.That(fetchedEntity.Key, Is.EqualTo(key));
        }

        [Test]
        public IList<Entity> GetPlayers()
        {
            MongoCollection<Entity> collection =
                MongoDBPool.Helper.MongoHelper.Instance.Database.GetCollection<Entity>("Entities");

            var x = collection.FindAll().ToList();
            return x;
        }



        //Testing Saving Player

    }

    public class MyPlayerTest
    {
        public ObjectId Id { get; set; }

        public string Pname { get; set; }


        public string PsurName { get; set; }

        public DateTime Datet { get; set; }


        //  [ScaffoldColumn(false)]
        //  public IList<> Results { get; set; }

    }


    [TestFixture]

    public class TestPlayers
    {
        [Test]
        public void TestPlayerConnection()
        {
            MongoCollection<MyPlayerTest> collection =
                MongoHelper.Instance.Database.GetCollection<MyPlayerTest>("players");
            // Assert.That(collection, Is.Null);
        }

        [Test]
        public void WriteReadDbTest()
        {
            string Pname = Guid.NewGuid().ToString();

            MyPlayerTest player = new MyPlayerTest {Pname = "siyabonga", PsurName = "Mbambo", Datet = DateTime.Today};



            MongoCollection<MyPlayerTest> collection =
                MongoHelper.Instance.Database.GetCollection<MyPlayerTest>("players");
            collection.Insert(player);



            MyPlayerTest fetchedEntity = collection.FindOne(Query.EQ("Pname", Pname));
            //Assert.That(fetchedEntity, Is.Null);
            // Assert.That(fetchedEntity.Pname, Is.EqualTo(Pname));
        }

       

        [Test]

        public void AddResults(ObjectId id, Results result)
        {

            MongoCollection<Player> collection = MongoHelper.Instance.Database.GetCollection<Player>("players");
            collection.Update(Query.EQ("_id", id), Update.PushWrapped("Results", result));
        }


        public class ResultHelper
        {
            private static MongoDBPool.Helper.ResultHelper _instance;

            public static MongoDBPool.Helper.ResultHelper Instance
            {
                get { return _instance ?? (_instance = new MongoDBPool.Helper.ResultHelper()); }
            }

            private MongoServer _server;

            public MongoDatabase Database
            {
                get { return Server.GetDatabase("TournamentDatabase"); }
            }

            private MongoServer Server
            {
                get
                {
                    if (_server == null || _server.State != MongoServerState.Connected)
                    {
                        _server = CreateServer();
                    }
                    return _server;
                }
            }


            private MongoServer CreateServer()
            {
                // TODO: refactor connection string into AppSetting
                string connectionString = "mongodb://127.0.0.1";
                var server = MongoServer.Create(connectionString);
                return server;
            }



        }

        [Test]
        public void ResultWriteReadDbTest()
        {
            string key = Guid.NewGuid().ToString();

            var entity = new Entity
            {
                Key = key,
                Name = "test",
                Number = 123,
            };

            MongoCollection<Entity> collection = ResultHelper.Instance.Database.GetCollection<Entity>("Result");
            collection.Insert(entity);

            Entity fetchedEntity = collection.FindOne(Query.EQ("Key", key));
            Assert.That(fetchedEntity, !Is.Null);
            Assert.That(fetchedEntity.Key, Is.EqualTo(key));
        }


    }
}





