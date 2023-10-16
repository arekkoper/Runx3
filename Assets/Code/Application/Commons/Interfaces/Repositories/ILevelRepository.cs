using Assets.Code.Domain.Entities;
using System.Collections.Generic;

namespace Assets.Code.Application.Commons.Interfaces.Repositories
{
    public interface ILevelRepository
    {
        void Add(Level level);
        Level GetById(int id);
        List<Level> GetAll();
    }
}
