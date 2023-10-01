
using Assets.Code.Domain.Entities;
using UnityEngine;

namespace Assets.Code.Infrastructure.Services
{
    public class PlayerService : IPlayerService
    {
        private Player _player;

        public Player Create()
        {
            _player = new Player()
            {
                Name = "Arek",
                Score = 0,
                ReverseMomentumMultiplier = 2.2f,
                Speed = 24f,
                TimeToMaxSpeed = 0.26f,
                TimeToLoseMaxSpeed = 0.2f
            };

            Load();

            return _player;
        }

        public Player GetPlayer()
        {
            return _player;
        }

        public int GetScore()
        {
            return _player.Score;
        }

        public void IncreaseScore()
        {
            _player.Score += 10;
        }

        public void ResetScore()
        {
            _player.Score = 0;
        }

        public void Save()
        {
            PlayerPrefs.SetInt("Score", _player.Score);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            _player.Score = PlayerPrefs.GetInt("Score");
        }
    }
}