
using Assets.Code.Application.Commons.Interfaces.Repositories;
using Assets.Code.Domain.Entities;
using log4net.Core;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Code.Infrastructure.Repositories
{
    public class CatcherRepository : ICatcherRepository
    {
        private int _counter;
        private List<Catcher> _data;

        public void Add(Catcher catcher)
        {
            _counter++;
            catcher.Id = _counter;
            _data.Add(catcher);
        }

        public List<Catcher> GetAll()
        {
            return _data;
        }

        public Catcher GetById(int id)
        {
            return _data.Where(item => item.Id == id).FirstOrDefault();
        }


    }
}