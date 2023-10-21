using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Commons.Interfaces.Spawners;
using Assets.Code.Application.Modules.Catcher.Commands.CreateCatcher;
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
        private Dictionary<Catcher, CatcherPresenter> _presenters = new();

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

            var catcher = _mediator.Send(new CreateCatcherCommand());
            var presenter = _factory.Create(catcher);

            _presenters.Add(catcher, presenter);

            presenter.transform.position = _spawnPoint.transform.position;

        }

        public void Unspawn()
        {
            foreach (var item in _presenters)
            {
                Object.Destroy(item.Value);
            }
            //if (_presenter != null)
            //    Object.Destroy(_presenter.gameObject);
        }

        public CatcherPresenter GetPresenter()
        {
            return _presenter;
        }

        public CatcherPresenter GetPresenter(int id)
        {
            return _presenters.Where(x => x.Key.Id == id).FirstOrDefault().Value;
        }

        public bool HasPresenter()
        {
            return _presenter != null;
        }

        public bool HasPresenter(int id)
        {
            return _presenters.Any(x => x.Key.Id == id);
        }
    }
}