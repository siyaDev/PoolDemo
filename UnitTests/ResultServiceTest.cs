
using System;
using System.Collections.Generic;
using MongoDBPool.IRepository;
using MongoDBPool.Models;
using MongoDBPool.Repository;
using MongoDBPool.Services;
using NUnit.Framework;
using Rhino.Mocks;

namespace UnitTests
{
    [TestFixture]
    public class ResultServiceTest
    {
        private Player _player;
        private Results _result;
        private ResultsService _service;
        private PlayerRepository _playerRepository;
        private PlayerRespositoryStub _playerRepositoryStub;
        PlayerValidator _playerValidator;
        private IList<Player> _playerList;

        [SetUp]
        public void SetUp()
        {
            _player = TestHelper.CreatePlayer();
            _result = TestHelper.CreateResults();
            _playerList = TestHelper.PlayerList();
            _playerValidator = new PlayerValidator();

            _playerRepository = new PlayerRepository();
            _playerRepositoryStub = new PlayerRespositoryStub();
            _service = new ResultsService(new PlayerRespositoryStub(), new ResultsRespositoryStub());
        }

        [Test]
        public void TestPlayerRegister()
        {
            var playerMock = MockRepository.GenerateMock<IPlayerRepository>();
            var palyerValidator = MockRepository.GenerateMock<IPlayerValidator>();
            palyerValidator.Stub(x => x.EmailValidator(_player)).Return(false);
            var playerRegistrionService = new RegistorPlayerService(playerMock, palyerValidator);
            playerRegistrionService.PlayerRegistration(_player);
            playerMock.AssertWasCalled(x => x.Save(_player));
        }

        [Test]
        public void TestReturned_Objects()
       {
           int expetedPoints = _service.CalculatePoints(_result).Count;    
           Assert.That(expetedPoints, Is.EqualTo(2));
        }

        [Test]
        public void Calcutating_Points()
        {
           var expetedPoints = _service.CalculatePoints(_result);

          //  expetedPoints
            int exp = 0;
           for (int i =0; i < expetedPoints.Count; i++ )
           {
               if (expetedPoints[i].Point == 6)
                   exp = expetedPoints[i].Point;
           }
           Assert.That(exp, Is.EqualTo(6));
        }

        [Test]
        public void Finding_the_OpponentStatus()
        {
            _service.ResultsEvaluation(_result);
            Assert.That(_result.OppnentStatus, Is.EqualTo("Loss"));
        }

        [Test]
        public void Finding_the_HostStatus()
        {
            _service.ResultsEvaluation(_result);
            Assert.That(_result.HostStatus, Is.EqualTo("Win"));
        }

        [Test]
        public void Should_Save_Player_On_Stub()
        {
            _playerRepositoryStub.Save(_player);
            int callend = _playerRepositoryStub.NumberOfPlayers;
            Assert.That(callend, Is.EqualTo(3));

        }
        //TestingRepository not stub
        [Test]
        public void Should_Save_Player_On_Repo()
        {
            _playerRepository.Save(_player);
            bool callend = _playerRepository.Validator();
            Assert.That(callend, Is.EqualTo(true));

        }

        /// <summary>
        /// This Test should not pass because is to  Test to Fail to delete a player id the id does not exist
        /// </summary>
        [Test]
        public void Should_not__delete_a_Player()
        {
            int DeletePlayerById = 3; // This id not in the player list
            _playerRepositoryStub.Delete(DeletePlayerById);
            int deletedPlayer = _playerRepositoryStub.playerWasDeleted;
            Assert.That(deletedPlayer, Is.EqualTo(1));
        }
        [Test]
        public void Should__delete_a_Player()
        {
            int DeletePlayerById = 5;
            _playerRepositoryStub.Delete(DeletePlayerById);
            int deletedPlayer = _playerRepositoryStub.playerWasDeleted;
            Assert.That(deletedPlayer, Is.EqualTo(1));
        }
        [Test]
        public void Sould_Update_Player()
        {

            var pla = MockRepository.GenerateMock<IPlayerRepository>();
            
            Player playerToUpDate = new Player();
            playerToUpDate.Id = 5;
            playerToUpDate.FirstName = "siyabonga";
            playerToUpDate.LastName = "mbambo";
            playerToUpDate.Age = 25;
            playerToUpDate.EmailAddress = "mbambos@yhoo.com";
            playerToUpDate.Point = 3;
            playerToUpDate.Date = DateTime.Now;
            _playerRepositoryStub.Update(playerToUpDate);
            String editedPlayer = _playerRepositoryStub.NewValue;

            Assert.That(editedPlayer, Is.EqualTo("siyabonga"));
        }

        [Test]
        public void Sould_not_Update_Player()
        {
            Player playerToUpDate = new Player();
            playerToUpDate.Id = 3;// This id is not in the player list
            playerToUpDate.FirstName = "siyabonga";
            playerToUpDate.LastName = "mbambo";
            playerToUpDate.Age = 25;
            playerToUpDate.EmailAddress = "mbambos@yhoo.com";
            playerToUpDate.Point = 3;
            playerToUpDate.Date = DateTime.Now;
            _playerRepositoryStub.Update(playerToUpDate);
            String EditedPlayer = _playerRepositoryStub.NewValue;
            Assert.That(EditedPlayer, Is.EqualTo("siyabonga"));

        }





    }
}
