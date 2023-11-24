using Code.Application.Commons.Interfaces.Services;
using Code.Domain.Entities;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public class PlayerService : IPlayerService
    {
        private Player _player;

        public Player Create()
        {
            _player = new Player()
            {
                Score = 0,
                ReverseMomentumMultiplier = 2.2f,
                Speed = 24f,
                TimeToMaxSpeed = 0.26f,
                TimeToLoseMaxSpeed = 0.2f
            };

            return _player;
        }

        public Player GetPlayer()
        {
            return _player;
        }

        public void ResetScore()
        {
            _player.Score = 0;
        }
    }
}