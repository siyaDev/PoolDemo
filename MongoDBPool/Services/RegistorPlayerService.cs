using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDBPool.IRepository;
using MongoDBPool.Models;

namespace MongoDBPool.Services
{
    public class RegistorPlayerService
    {
        private  IPlayerRepository _playerRepository;
        private IPlayerValidator _playerValidator;

        public RegistorPlayerService(IPlayerRepository playerRepository, IPlayerValidator  playerValidator)
        {
            _playerRepository = playerRepository;
            _playerValidator = playerValidator;
        }
        public Player PlayerRegistration(Player player)
        {
            bool isPlayeValid = _playerValidator.EmailValidator(player);

            if (isPlayeValid == false)
            {
                _playerRepository.Save(player);
            }
            else
            {
                player.EmailAddress = "Player Email Already Exist ";

            }
            return player;
        }
    }
}