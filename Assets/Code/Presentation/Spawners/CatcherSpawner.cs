﻿using Assets.Code.Presentation.Presenters;
using Assets.Code.Presentation.Spawners.Points;
using UnityEngine;

namespace Assets.Code.Presentation.Spawners
{
    public class CatcherSpawner
    {
        private CatcherPresenter _presenter;
        private CatcherSpawnPoint _spawnPoint;

        private readonly CatcherPresenter.Factory _factory;

        public CatcherSpawner(CatcherPresenter.Factory factory)
        {
            _factory = factory;
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
                Object.Destroy(_presenter.gameObject);
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