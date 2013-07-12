using System;
using System.ComponentModel.DataAnnotations;

namespace MongoDBPool.Models
{
    public class Player
    {
        [ScaffoldColumn(true)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public DateTime Date { get; set; }
        [ScaffoldColumn(true)]
        public string FirstName { get; set; }
        [ScaffoldColumn(true)]
        public string LastName { get; set; }
        [ScaffoldColumn(true)]
        public int Age { get; set; }
        [ScaffoldColumn(true)]
        public string EmailAddress { get; set; }

        public int Point { get; set; }
        public int Wins { get; set; }
        public int Loss { get; set; }
        public int AwayGames { get; set; }
        public int HomeGames { get; set; }
        public int Total { get; set; }
        public int TotalBallsScored { get; set; }
        public int TotalBallsScoredAgainst { get; set; }
        public int BallDefference { get; set; }

        public Player(int id, string fname, string lstName, int age, string email)
        {
           Id = id;
           FirstName = fname;
           LastName = lstName;
           Age = age;
           EmailAddress = email;
        }
        public Player( string fname, string lstName, int age, string email)
        {   
            FirstName = fname;
            LastName = lstName;
            Age = age;
            EmailAddress = email;
        }
        public Player(int id)
        {
          this.Id = id;         
        }
        public Player(string fname, string lstName, int age)
        {
            FirstName = fname;
            LastName = lstName;
            Age = age;
            Date = DateTime.Now;
        }
        public Player()
        { }




    }
}