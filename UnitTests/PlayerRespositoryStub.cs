using System;
using System.Collections.Generic;
using System.Linq;
using MongoDBPool.IRepository;
using MongoDBPool.Models;

namespace UnitTests
{
    class PlayerRespositoryStub : IPlayerRepository
    {
        public IList<Player> PlayersToReturn;
        public Player PlayerToReturn;
        public String NewValue;
        public int NumberOfPlayers;
        public int PlayerWasSave;
        public int UpdatePoints;

        public int playerWasDeleted; 
      public IList<Player> SelectAllAsList()
      {
          if (PlayersToReturn == null)
              return TestHelper.PlayerList();
          return PlayersToReturn;
      }

      public Player SelectById(int playerId)
      {
          if (PlayerToReturn == null)
              return TestHelper.CreatePlayer();
          return PlayerToReturn;

      }
        public void Save(Player player)
        {
            IList<Player> playerList = TestHelper.PlayerList();

            if (player != null)
            {
                playerList.Add(player);
            }

            if (playerList.Count() > TestHelper.PlayerList().Count)
            {
                PlayerWasSave = 1;
            }

            NumberOfPlayers = playerList.Count();
        }

        public void Delete(int playerId)
        {

            IList<Player> playerList = new List<Player>();
                    playerList  = TestHelper.PlayerList();
                     for (int i = 0; i < playerList.Count; i++)
                     {
                         if (playerList[i].Id == playerId)
                             playerList.RemoveAt(i);
                     }
                     playerWasDeleted = playerList.Count;       
        }

        public void Update(Player player)
        {
           IList<Player> playerList = new List<Player>();

            playerList = TestHelper.PlayerList();
            var UpdatePlayer = playerList.Where(x => x.Id == player.Id).Single();
            if (UpdatePlayer != null)
            {
                UpdatePlayer.Id = player.Id;
                UpdatePlayer.FirstName = player.FirstName;
                UpdatePlayer.LastName = player.LastName;
                UpdatePlayer.Age = player.Age;
                UpdatePlayer.Point = player.Point;
                UpdatePlayer.EmailAddress = player.EmailAddress;
                UpdatePlayer.Date = player.Date;
            }
            // Editing Player Object
            NewValue = UpdatePlayer.FirstName;

            //UpdatePlayer Points
            UpdatePoints = UpdatePlayer.Point;







        }
    }
}
