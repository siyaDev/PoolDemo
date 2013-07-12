
using System.Collections.Generic;
using MongoDBPool.IRepository;
using MongoDBPool.Models;
namespace MongoDBPool.Services
{
    public class ResultsService 
    {
        private readonly IPlayerRepository _playerReposistory;
        private readonly IResultRepository _resultRepository;
       public Player HostingPlayer;
       public Player OpponentPlayer;

        public List<Player> UpadetedPlayer;
        public Results SaveResults;

        // using injection
        public ResultsService(IPlayerRepository  playerRepository, IResultRepository resultRepository)
        {
            _playerReposistory = playerRepository;
            _resultRepository = resultRepository;   
        }

        // Calcutating Points for the Player
        public List<Player> CalculatePoints(Results resuluts)
        {
            HostingPlayer = _playerReposistory.SelectById(resuluts.HostId);
            OpponentPlayer =  _playerReposistory.SelectById(resuluts.OppenentId);

             if (OpponentPlayer.Id == resuluts.BlackBallPayerId && resuluts.OppnetBallsLeft == 0)
            {
                OpponentPlayer.Point = OpponentPlayer.Point + 3;
                OpponentPlayer.Wins = OpponentPlayer.Wins + 1;
                OpponentPlayer.AwayGames = OpponentPlayer.AwayGames + 1;
                OpponentPlayer.TotalBallsScored = OpponentPlayer.TotalBallsScored + (8 - resuluts.OppnetBallsLeft);
                OpponentPlayer.TotalBallsScoredAgainst = OpponentPlayer.TotalBallsScoredAgainst + (8 - resuluts.HosBallsLeft);
                OpponentPlayer.BallDefference = OpponentPlayer.TotalBallsScored - OpponentPlayer.TotalBallsScoredAgainst;
                OpponentPlayer.Total = OpponentPlayer.Total + 1;

                HostingPlayer.Loss = HostingPlayer.Loss + 1;
                HostingPlayer.HomeGames = HostingPlayer.HomeGames + 1;
                HostingPlayer.TotalBallsScored = HostingPlayer.TotalBallsScored + (8 - resuluts.HosBallsLeft);
                HostingPlayer.TotalBallsScoredAgainst = HostingPlayer.TotalBallsScoredAgainst + (8 - resuluts.OppnetBallsLeft);
                HostingPlayer.BallDefference = HostingPlayer.TotalBallsScored - HostingPlayer.TotalBallsScoredAgainst;
                HostingPlayer.Total = HostingPlayer.Total + 1;
            }

             if (HostingPlayer.Id == resuluts.BlackBallPayerId && resuluts.HosBallsLeft > 0)
             {
                 OpponentPlayer.Point = OpponentPlayer.Point + 3;
                 OpponentPlayer.Wins = OpponentPlayer.Wins + 1;
                 OpponentPlayer.AwayGames = OpponentPlayer.AwayGames + 1;
                 OpponentPlayer.TotalBallsScored = OpponentPlayer.TotalBallsScored + (8 - resuluts.OppnetBallsLeft);
                 OpponentPlayer.TotalBallsScoredAgainst = OpponentPlayer.TotalBallsScoredAgainst + (8 - resuluts.HosBallsLeft);
                 OpponentPlayer.BallDefference = OpponentPlayer.TotalBallsScored - OpponentPlayer.TotalBallsScoredAgainst;
                 OpponentPlayer.Total = OpponentPlayer.Total + 1;

                 HostingPlayer.Loss = HostingPlayer.Loss + 1;
                 HostingPlayer.HomeGames = HostingPlayer.HomeGames + 1;
                 HostingPlayer.TotalBallsScored = HostingPlayer.TotalBallsScored + (8 - resuluts.HosBallsLeft);
                 HostingPlayer.TotalBallsScoredAgainst = HostingPlayer.TotalBallsScoredAgainst + (8 - resuluts.OppnetBallsLeft);
                 HostingPlayer.BallDefference = HostingPlayer.TotalBallsScored - HostingPlayer.TotalBallsScoredAgainst;
                 HostingPlayer.Total = HostingPlayer.Total + 1;

             }

             if (HostingPlayer.Id == resuluts.BlackBallPayerId && resuluts.HosBallsLeft == 0)
            {
                HostingPlayer.Point = HostingPlayer.Point + 3;
                HostingPlayer.Wins = HostingPlayer.Wins + 1;
                HostingPlayer.HomeGames = HostingPlayer.HomeGames + 1;
                HostingPlayer.TotalBallsScored = HostingPlayer.TotalBallsScored + (8 - resuluts.HosBallsLeft);
                HostingPlayer.TotalBallsScoredAgainst = HostingPlayer.TotalBallsScoredAgainst + (8 - resuluts.OppnetBallsLeft);
                HostingPlayer.BallDefference = HostingPlayer.TotalBallsScored - HostingPlayer.TotalBallsScoredAgainst;
                HostingPlayer.Total = HostingPlayer.Total + 1;

                OpponentPlayer.Loss = OpponentPlayer.Loss + 1;
                OpponentPlayer.AwayGames = OpponentPlayer.AwayGames + 1;
                OpponentPlayer.TotalBallsScored = OpponentPlayer.TotalBallsScored + (8 - resuluts.OppnetBallsLeft);
                OpponentPlayer.TotalBallsScoredAgainst = OpponentPlayer.TotalBallsScoredAgainst + (8 - resuluts.HosBallsLeft);
                OpponentPlayer.BallDefference = OpponentPlayer.TotalBallsScored - OpponentPlayer.TotalBallsScoredAgainst;
                OpponentPlayer.Total = OpponentPlayer.Total + 1;

            }
            if (OpponentPlayer.Id == resuluts.BlackBallPayerId && resuluts.OppnetBallsLeft > 0)
            {
                HostingPlayer.Point = HostingPlayer.Point + 3;
                HostingPlayer.Wins = HostingPlayer.Wins + 1;
                HostingPlayer.HomeGames = HostingPlayer.HomeGames + 1;
                HostingPlayer.TotalBallsScored = HostingPlayer.TotalBallsScored + (8 - resuluts.HosBallsLeft);
                HostingPlayer.TotalBallsScoredAgainst = HostingPlayer.TotalBallsScoredAgainst + (8 - resuluts.OppnetBallsLeft);
                HostingPlayer.BallDefference = HostingPlayer.TotalBallsScored - HostingPlayer.TotalBallsScoredAgainst;
                HostingPlayer.Total = HostingPlayer.Total + 1;
                HostingPlayer.Wins = HostingPlayer.Wins + 1;

                OpponentPlayer.Loss = OpponentPlayer.Loss + 1;
                OpponentPlayer.AwayGames = OpponentPlayer.AwayGames + 1;
                OpponentPlayer.TotalBallsScored = OpponentPlayer.TotalBallsScored + (8 - resuluts.OppnetBallsLeft);
                OpponentPlayer.TotalBallsScoredAgainst = OpponentPlayer.TotalBallsScoredAgainst + (8 - resuluts.HosBallsLeft);
                OpponentPlayer.BallDefference = OpponentPlayer.TotalBallsScored - OpponentPlayer.TotalBallsScoredAgainst;
                OpponentPlayer.Total = OpponentPlayer.Total + 1;

            }
               UpadetedPlayer = new List<Player>();
               UpadetedPlayer.Add(HostingPlayer);
               UpadetedPlayer.Add(OpponentPlayer);
              _playerReposistory.Update(HostingPlayer);
               _playerReposistory.Update(OpponentPlayer);

              return UpadetedPlayer;
         }          

        //Determing The winner
        public Results ResultsEvaluation(Results results)
        {
             var hostingPlayer = _playerReposistory.SelectById(results.HostId);
             var opponentPlayer = _playerReposistory.SelectById(results.OppenentId);

             if (opponentPlayer.Id == results.BlackBallPayerId && results.OppnetBallsLeft == 0)
            {
                results.OppnentStatus = "Win";
                results.HostStatus = "Loss";
                _resultRepository.Save(results);
            }
             if (hostingPlayer.Id == results.BlackBallPayerId && results.HosBallsLeft > 0)
              {
                  results.OppnentStatus = "Win";
                  results.HostStatus = "Loss";
                  _resultRepository.Save(results);
             }
             if (opponentPlayer.Id == results.BlackBallPayerId && results.OppnetBallsLeft > 0)
           {
               results.OppnentStatus = "Loss"; 
               results.HostStatus = "Win";
               _resultRepository.Save(results);
           }

             if (hostingPlayer.Id == results.BlackBallPayerId && results.HosBallsLeft == 0)
             {
                 results.OppnentStatus = "Loss";
                 results.HostStatus = "Win";
                 _resultRepository.Save(results);
             }
           //  SaveResults.Add(results);


            return   SaveResults;
;
        }


    }
}