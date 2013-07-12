
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MongoDBPool.DAL;

using MongoDBPool.IRepository;
using MongoDBPool.Models;

//using Mong/oDBPool.DAL;
 

namespace MongoDBPool.Repository
{
    public class PlayerRepository : IPlayerRepository

{
       private bool playerRpo = false;


        public bool Validator()
        {
            playerRpo = true;
           
          return playerRpo;
        }

        public  IList<Player> SelectAllAsList()
        {
            return (MultipleInnerSelect(SqlHelper.ExecuteDataset(DaLplayer.ConnectionString(), "[p_SelectPlayers_All]")));
        }

        public IList<Player> MultipleInnerSelect( DataSet dsMessage)
        {
          
            IList<Player> players = new List<Player>();

            if (dsMessage.Tables[0].Rows.Count > 0)
            {
                
                foreach (DataRow row in dsMessage.Tables[0].Rows)
                {
                    Player player = new Player();
                    
                    if (row["PlayerID"] != System.DBNull.Value)
                        player.Id = (int)row["PlayerID"];

                    if (row["FirstName"] != System.DBNull.Value)
                        player.FirstName = (string) row["FirstName"];

                    if (row["LastName"] != System.DBNull.Value)
                        player.LastName = (string)row["LastName"];

                    if (row["Age"] != System.DBNull.Value)
                        player.Age = (int)row["Age"];

                    if (row["EmailAddress"] != System.DBNull.Value)
                        player.EmailAddress = (string)row["EmailAddress"];

                    if (dsMessage.Tables[0].Rows[0]["Points"] != System.DBNull.Value)
                        player.Point = (int)dsMessage.Tables[0].Rows[0]["Points"];
                    players.Add(player);
                }
            }
            return players;
        }

        public Player SelectById(int playerId)
        {
            object[] parameterValues =
            {
                new SqlParameter("@PlayerID",playerId)
            };
            return (InnerSelect(SqlHelper.ExecuteDataset(DaLplayer.ConnectionString(), "[ByPlayerId]", parameterValues)));

        }
        public Player InnerSelect(DataSet dsMessage)
        {
           Player player = null;

            if (dsMessage.Tables[0].Rows.Count > 0)
            {
                player = new Player();
             
                if (dsMessage.Tables[0].Rows[0]["PlayerID"] != System.DBNull.Value)
                    player.Id = (int)dsMessage.Tables[0].Rows[0]["PlayerID"];

                if (dsMessage.Tables[0].Rows[0]["FirstName"] != System.DBNull.Value)
                    player.FirstName = (string)dsMessage.Tables[0].Rows[0]["FirstName"];

                 if (dsMessage.Tables[0].Rows[0]["LastName"] != System.DBNull.Value)
                    player.LastName = (string)dsMessage.Tables[0].Rows[0]["LastName"];

                if (dsMessage.Tables[0].Rows[0]["Age"] != System.DBNull.Value)
                   player.Age = (int)dsMessage.Tables[0].Rows[0]["Age"];

                if (dsMessage.Tables[0].Rows[0]["EmailAddress"] != System.DBNull.Value)
                    player.EmailAddress = (string)dsMessage.Tables[0].Rows[0]["EmailAddress"];

                if (dsMessage.Tables[0].Rows[0]["Points"] != System.DBNull.Value)
                    player.Point = (int)dsMessage.Tables[0].Rows[0]["Points"];

                if (dsMessage.Tables[0].Rows[0]["Wins"] != System.DBNull.Value)
                    player.Wins = (int)dsMessage.Tables[0].Rows[0]["Wins"];

                if (dsMessage.Tables[0].Rows[0]["Loss"] != System.DBNull.Value)
                    player.Loss = (int)dsMessage.Tables[0].Rows[0]["Loss"];

                if (dsMessage.Tables[0].Rows[0]["AwayGames"] != System.DBNull.Value)
                    player.AwayGames = (int)dsMessage.Tables[0].Rows[0]["AwayGames"];

                if (dsMessage.Tables[0].Rows[0]["HomeGames"] != System.DBNull.Value)
                    player.HomeGames = (int)dsMessage.Tables[0].Rows[0]["HomeGames"];

                if (dsMessage.Tables[0].Rows[0]["Total"] != System.DBNull.Value)
                    player.Total = (int)dsMessage.Tables[0].Rows[0]["Total"];

                if (dsMessage.Tables[0].Rows[0]["BF"] != System.DBNull.Value)
                    player.TotalBallsScored = (int)dsMessage.Tables[0].Rows[0]["BF"];

                if (dsMessage.Tables[0].Rows[0]["BA"] != System.DBNull.Value)
                    player.TotalBallsScoredAgainst = (int)dsMessage.Tables[0].Rows[0]["BA"];

                if (dsMessage.Tables[0].Rows[0]["BD"] != System.DBNull.Value)
                    player.BallDefference = (int)dsMessage.Tables[0].Rows[0]["BD"];
            }

            
            


            
            return player;
        }   

        public void Save(Player player)
        {
            object[] parameterValues =
            {
                new SqlParameter("@PlayerFirstName",player.FirstName),   
                new SqlParameter("@PlayerLatName",player.LastName),
                new SqlParameter("@Age",player.Age),
                new SqlParameter("@Email", player.EmailAddress),
                
               
            };
            SqlHelper.ExecuteScalar(DaLplayer.ConnectionString(), "[SavePlayer]", parameterValues);
        }     

        public  void Delete(int playerId)
        {        
            object[] parameterValues =
            {
                new SqlParameter("@p_id",playerId)
             
            };
            SqlHelper.ExecuteScalar(DaLplayer.ConnectionString(), "p_DeleplayerById", parameterValues);
        }

        public  void Update(Player player)
        {
            object[] parameterValues =
            {
                new SqlParameter("@p_id",player.Id),  
                new SqlParameter("@FirstName",player.FirstName),   
                new SqlParameter("@LastName",player.LastName),
                new SqlParameter("@Age",player.Age),
                new SqlParameter("@EmailAddress",player.EmailAddress),
                new SqlParameter("@Point", player.Point),
                new SqlParameter("@Wins", player.Wins),
                new SqlParameter("@Loss", player.Loss),
                new SqlParameter("@AwayGames", player.AwayGames),
                new SqlParameter("@HomeGames", player.HomeGames),
                new SqlParameter("@Total", player.Total),
                new SqlParameter("@BF", player.TotalBallsScored),
                new SqlParameter("@BA", player.TotalBallsScoredAgainst),
                new SqlParameter("@BD", player.BallDefference),
               
            };
            SqlHelper.ExecuteScalar(DaLplayer.ConnectionString(), "p_updatePlayer", parameterValues);
        }
}
}