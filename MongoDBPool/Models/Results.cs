using System;

namespace MongoDBPool.Models
{

    public class Results 
    {
        public int _id { get; set; }
        public int HostId { get; set; }
        public int OppenentId { get; set; }     
        public DateTime Date  { get; set; }
        public int HosBallsLeft { get; set; }
        public int OppnetBallsLeft { get; set; }
        public string OppnetName { get; set; }
        public string HostName { get; set; }
        public int HostPoints { get; set; }
        public int OpponentPoints{ get; set; }
        public string HostStatus { get; set; }
        public string OppnentStatus { get; set; }

        public int BlackBallPayerId { get; set; }
        public int BlackBall { get; set; }


        public Results(){}

        public Results(int hostId, int oppId, DateTime date, int hosBal, int oppnetBall, int blackBallPayerId, int blackBall)
        {
            HostId = hostId;
            OppenentId = oppId;
            Date = date;
            HosBallsLeft = hosBal;
            OppnetBallsLeft = oppnetBall;
            BlackBallPayerId = blackBallPayerId;
            BlackBall = blackBall;

        }

        public Results(int id, int hostBallsLeft, int oppnentBallsLeft)
        {
            _id = id;
            HosBallsLeft = hostBallsLeft;
            OppnetBallsLeft = oppnentBallsLeft;
         
        }

    }
}
