
using Assets.Code.Application.Commons.Interfaces.Repositories;
using Assets.Code.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Code.Infrastructure.Repositories
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
    }
}