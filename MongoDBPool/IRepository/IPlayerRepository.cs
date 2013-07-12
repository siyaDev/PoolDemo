using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDBPool.Models;

namespace MongoDBPool.IRepository
{
    public interface IPlayerRepository
    {

        IList<Player> SelectAllAsList();
        Player SelectById(int playerId);
        void Save(Player player);
        void Delete(int playerId);
        void Update(Player player);

    }
}
