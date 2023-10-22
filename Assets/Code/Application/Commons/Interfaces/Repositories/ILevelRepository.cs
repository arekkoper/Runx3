using System.Collections.Generic;
using Code.Domain.Entities;

namespace Code.Application.Commons.Interfaces.Repositories
{
    public interface ILevelRepository
    {
        void Add(Level level);
        Level GetById(int id);
        List<Level> GetAll();
    }
}
