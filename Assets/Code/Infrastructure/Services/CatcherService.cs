
using Assets.Code.Application.Commons.Interfaces.Repositories;
using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Assets.Code.Infrastructure.Services
{
    public class CatcherService : ICatcherService
    {
        private readonly ICatcherRepository _repository;
        private readonly Settings _settings;

        public CatcherService(ICatcherRepository repository, Settings settings)
        {
            _repository = repository;
            _settings = settings;
        }

        [Serializable]
        public class Settings
        {
            public float Speed;
            public float MinRetargetInterval;
            public float MaxRetargetInterval;
            public float RotationTime;
            public float PostRotationWaitTime;
        }

        public Catcher Create()
        {
            var catcher = new Catcher()
            {
                Speed = _settings.Speed,
                MinRetargetInterval = _settings.MinRetargetInterval,
                MaxRetargetInterval = _settings.MaxRetargetInterval,
                RotationTime = _settings.RotationTime,
                PostRotationWaitTime = _settings.PostRotationWaitTime
            };

            _repository.Add(catcher);

            return catcher;
        }

        public Catcher GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Catcher> GetAll()
        {
            return _repository.GetAll();
        }
    }
}