using System;
using System.Collections.Generic;
using MongoDBPool.Models;

namespace TestIntergrated
{
   
    public class TestHelper
    {
        public static Player CreatePlayer()
        {
            var player = new Player()
                             {  Id = 8, FirstName = "Kaya",LastName = "Vena",Age = 27, Point = 3, EmailAddress = "kavena@yhoo.com", Date = DateTime.Now
                             };
            new Player() { Id = 9, FirstName = "siya", LastName = "mbambo", Age = 25, Point = 3, EmailAddress = "mbambos@yhoo.com", Date = DateTime.Now };          
            return player;
        } 
        public static IList<Player> PlayerList()
        {
            var player = new List<Player>(12);
            player.Add(new Player() { Id = 5, FirstName = "siya", LastName = "mbambo", Age = 25, Point = 3, EmailAddress = "mbambos@yhoo.com", Date = DateTime.Now });
            player.Add(new Player() { Id = 6, FirstName = "siya1", LastName = "mbambo", Age = 25, Point = 3, EmailAddress = "mbambos@yhoo.com", Date = DateTime.Now });
            return player;
        }

        public static Results CreateResults()
        {
            var results = new Results();
            results._id = 1;
            results.HostId = 9;
            results.OppenentId = 10;
            results.OppnetBallsLeft = 5;
            results.HosBallsLeft = 0;
            results.BlackBallPayerId = 9;
            results.Date = DateTime.Now;

            return results;
        }
        
        public static IList<Results> ResultsList()
        {
            var results = new List<Results>();

            results.Add(CreateResults());
            results.Add(CreateResults());
            results.Add(CreateResults());

            return results;
        }

    











    }
}
