using System;
using System.Collections.Generic;
using System.Linq;
using MongoDBPool.Models;
using MongoDBPool.Repository;
using MongoDBPool.Services;
using NUnit.Framework;

using Assert = NUnit.Framework.Assert;


namespace TestIntergrated
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class IntergratedTesting
    {
        private Player _player;
        private Results _result;
        private ResultsService _service;
        private PlayerRepository _playerRepository;
        private IList<Player> _playerList;

        [SetUp]
        public void SetUp()
        {
            _player = TestHelper.CreatePlayer();
            _result = TestHelper.CreateResults();
            _playerList = TestHelper.PlayerList();
            _playerRepository = new PlayerRepository();       
            _service = new ResultsService(new PlayerRepository(), new ResultRepository());
        }

        [Test]
        public void TestReturnedObjects()
        {
            int expetedPoints = _service.CalculatePoints(_result).Count;
            Assert.That(expetedPoints, Is.EqualTo(2));
        }

        [Test]
        public void CalcutatingPoints()
        {
        _playerList = _service.CalculatePoints(_result);
         var expected = _playerList.Select(p => p).Where(x => x.Id == 9).Single();
        Assert.That(expected.Point, Is.EqualTo(18));
        }

        [Test]
        public void FindingtheOpponentStatus()
        {
            _service.ResultsEvaluation(_result);
            Assert.That(_result.OppnentStatus, Is.EqualTo("Loss"));
        }

        [Test]
        public void FindingTheHostStatus()
        {
            _service.ResultsEvaluation(_result);
            Assert.That(_result.HostStatus, Is.EqualTo("Win"));
        }

        //Testing PlayerRepository not stub
        [Test]
        public void Should_Save_Player_On_Repo()
        {
            _playerRepository.Save(_player);
            _playerList = _playerRepository.SelectAllAsList();
            var newPlayer = _playerList.Where(x => x.Id == 30).Single();
            Assert.That(newPlayer.FirstName, Is.EqualTo("Kaya"));

        }

        /// <summary>
        /// This Test should not pass because is to  Test to Fail to delete a player id the id does not exist
        /// </summary>
        
        [Test]
        public void ShouldDeletePlayer()
        {
            bool deletedPlayer = false;
            _playerRepository.Delete(2);
            try
            {
           _playerRepository.SelectAllAsList().Select(p => p).Where(x => x.Id == 2);
           deletedPlayer = true;
            }
            catch (InvalidOperationException) {}
            Assert.That(deletedPlayer, Is.EqualTo(true));


        }
        [Test]
        public void SouldUpdatePlayer()
        {
            Player playerToUpDate = new Player();
            playerToUpDate.Id = 14;
            playerToUpDate.FirstName = "siyabonga";
            playerToUpDate.LastName = "mbambo";
            playerToUpDate.Age = 25;
            playerToUpDate.EmailAddress = "mbambos@yhoo.com";
            playerToUpDate.Point = 23;
            playerToUpDate.Date = DateTime.Now;
           _playerRepository.Update(playerToUpDate);
           bool editedPlayer = _playerRepository.Validator();
           Assert.That(editedPlayer, Is.EqualTo(true));
        }

   

    }
}
