using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDBPool.IRepository;
using MongoDBPool.Models;

namespace MongoDBPool.Repository
{
    public class PlayerValidator : IPlayerValidator
    {

        public PlayerRepository PlayerRepo;
        public  IList<Player> playerList;
        public string newPlayerEmail;
        public bool emailChacking = false;

        public PlayerValidator()
        {
            PlayerRepo = new PlayerRepository();
        }
        public bool EmailValidator(Player player)
        {
            playerList = PlayerRepo.SelectAllAsList();
            try
            {
                playerList.Select(p => p).Where(x => x.EmailAddress == player.EmailAddress).Single();
                emailChacking = true;
            }
             catch(InvalidOperationException){ }
            return emailChacking;
        }
    }
}