
using Assets.Code.Domain.Entities;
using System.Collections.Generic;

namespace Assets.Code.Application.Commons.Interfaces.Services
{
    public interface ICatcherService
    {
        Catcher Create();
        List<Catcher> GetAll();
        Catcher GetById(int id);
    }
}