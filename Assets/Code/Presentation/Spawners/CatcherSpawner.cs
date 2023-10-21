using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Commons.Interfaces.Spawners;
using Assets.Code.Domain.Entities;
using Assets.Code.Presentation.Presenters;
using Assets.Code.Presentation.Spawners.Points;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Code.Presentation.Spawners
{
    public class CatcherSpawner : ICatcherSpawner
    {
        private CatcherPresenter _presenter;
        private CatcherSpawnPoint _spawnPoint;

        private readonly CatcherPresenter.Factory _factory;
        private readonly IMediator _mediator;

        public CatcherSpawner(CatcherPresenter.Factory factory, IMediator mediator)
        {
            _factory = factory;
            _mediator = mediator;
        }

        public void SetSpawnPoint(CatcherSpawnPoint spawnPoint)
        {
            _spawnPoint = spawnPoint;
        }

        public void Spawn()
        {
            Unspawn();

            if (_spawnPoint == null) return;

            _presenter = _factory.Create();

            _presenter.transform.position = _spawnPoint.transform.position;

        }

        public void Unspawn()
        {
            if(_presenter != null)
            {
                Object.Destroy(_presenter.gameObject);
            }
        }

        public CatcherPresenter GetPresenter()
        {
            return _presenter;
        }

        public bool HasPresenter()
        {
            return _presenter != null;
        }
    }
}