using System.Collections.Generic;
using Code.Application.Commons.Interfaces.Repositories;
using Code.Application.Commons.Interfaces.Services;
using Code.Domain.Entities;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _repository;

        public LevelService(ILevelRepository repository)
        {
            _repository = repository;
        }

        public Level Create()
        {
            var level = new Level()
            {
                TheBestScore = 0,
                Deaths = 0,
                IsAvailable = false,
                IsRunning = false
            };

            _repository.Add(level);

            level.Thumbnail = Resources.Load<Sprite>($"Sprites/Level Previews/Spr_Level_Preview_{level.Id}");

            return level;
        }

        public Level GetLevelById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Level> GetLevels()
        {
            return _repository.GetAll();
        }

    }
}