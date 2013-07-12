using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDBPool.Helper;
using MongoDBPool.Models;

namespace MongoDBPool.Services
{
    public class ResultService
    {
        private MongoHelper _resultService;
        private const string CollectionName = "results";

        public ResultService()
        {
            _resultService = new MongoHelper();
        }

        public void AddResults(Results result)
        {
            MongoCollection<Player> collection = MongoHelper.Instance.Database.GetCollection<Player>(CollectionName);
            collection.Insert(result);
        }

        public List<Results> GetResults(int playerId)
        {
            MongoCollection<Results> collection = MongoHelper.Instance.Database.GetCollection<Results>(CollectionName);
            var query = Query.Or((Query.EQ("Player1", playerId)),
                Query.EQ("Player2", playerId));
            var result = collection.Find(query);          

            return result.ToList();

        }



    }
}

