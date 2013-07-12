
using System.Collections.Generic;
using MongoDBPool.Models;

namespace MongoDBPool.IRepository
{
    public interface IResultRepository
    {
        IList<Results> SelectAllAsList();
        Results SelectById(int playerId);
        void Save(Results player);
        void Delete(int playerId);
        void Update(Results player);
    }
}