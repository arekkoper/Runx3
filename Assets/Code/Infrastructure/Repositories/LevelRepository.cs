using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Interfaces.Repositories;
using Code.Domain.Entities;

namespace Code.Infrastructure.Repositories
{
    public class LevelRepository : ILevelRepository
    {

        private int _counter;
        private List<Level> _levels = new();

        public void Add(Level level)
        {
            _counter++;
            level.Id = _counter;
            _levels.Add(level);
        }

        public List<Level> GetAll()
        {
            return _levels;
        }

        public Level GetById(int id)
        {
            return _levels.Where(level => level.Id == id).FirstOrDefault();
        }

        [Serializable]
        public struct Data
        {
            public List<Level> Levels { get; set; }
            public int Counter { get; set; }
        }

        public object CaptureState()
        {
            var data = new Data
            {
                Levels = _levels,
                Counter = _counter
            };

            return data;
        }

        public void RestoreState(object state)
        {
            Data data = (Data)state;

            _counter = data.Counter;
            _levels = data.Levels;
        }

    }
}