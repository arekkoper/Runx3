
using Assets.Code.Domain.Entities;
using System.Collections.Generic;

namespace Assets.Code.Application.Commons.Interfaces.Repositories
{
    public interface ICatcherRepository
    {
        void Add(Catcher catcher);
        List<Catcher> GetAll();
        Catcher GetById(int id);
    }
}