using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDBPool.Helper;
using MongoDBPool.Models;

namespace MongoDBPool.MongoDbRepository
{
    public class PlayerMongoDRepository
    {
        private  string collName ="players";
        private  MongoHelper _playerService;

        public PlayerMongoDRepository()
        {
            _playerService = new MongoHelper();
        }

        public IList<Player> GetPlayers()
        {
            MongoCollection<Player> collection = MongoHelper.Instance.Database.GetCollection<Player>(collName);
            return collection.FindAll().ToList();
        }

        public IList<Player> GetPlayers(int id)
        {
            MongoCollection<Player> collection = MongoHelper.Instance.Database.GetCollection<Player>(collName);
           return collection.Find(Query.NE("_id", id)).ToList();
        }

        public void Create(Player player)
        { 
            MongoCollection<Player> collection = MongoHelper.Instance.Database.GetCollection<Player>(collName);
            collection.Insert(player);
        }

        public Player GetPlayer(int id)
        {
            MongoCollection<Player> collection = MongoHelper.Instance.Database.GetCollection<Player>(collName);
            var palyer = collection.Find(Query.EQ("_id", id)).Single();
            return palyer;
        }

        public void Edit(Player player)
        {
            MongoCollection<Player> collection = MongoHelper.Instance.Database.GetCollection<Player>(collName);
            collection.Update(
                Query.EQ("_id", player.Id),
                Update.Set("FirstName", player.FirstName)
                    .Set("LastName", player.LastName)
                    .Set("Age", player.Age));
        }

      
        public void Delete(int id)
        {
            MongoCollection<Player> collection = MongoHelper.Instance.Database.GetCollection<Player>(collName);

            collection.Remove(Query.EQ("_id", id));
           
        }
        
        



    }
}