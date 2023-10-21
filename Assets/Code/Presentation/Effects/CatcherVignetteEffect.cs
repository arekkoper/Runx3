﻿
using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Application.Commons.Interfaces.Spawners;
using Assets.Code.Presentation.Spawners;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Effects
{
    public class CatcherVignetteEffect : IInitializable, ITickable
    {
        private readonly PlayerSpawner _playerSpawner;
        private readonly ICatcherSpawner _catcherSpawner;
        private readonly IPostProcessService _postProcessService;

        private float _distance;
        private float _originVignetteIntensity;
        private float _currentVignetteIntensity;
        private float _startDistance;
        private double _angle;
        private float _offset;

        public CatcherVignetteEffect(PlayerSpawner playerSpawner, ICatcherSpawner catcherSpawner, IPostProcessService postProcessService)
        {
            _playerSpawner = playerSpawner;
            _catcherSpawner = catcherSpawner;
            _postProcessService = postProcessService;
        }

        public void Initialize()
        {
            _startDistance = 30f;
            _angle = -0.0357;   // parameter "a" in function y=ax+b
            _offset = 1.07f;    // parameter "b" in function y=ax+b
        }

        public void Tick()
        {
            if (_playerSpawner == null || _catcherSpawner == null) return;
            if (!_playerSpawner.HasPresenter() || !_catcherSpawner.HasPresenter(1)) return;

            CalculateDistance();

            if (_distance > _startDistance) return;

            RefreshVignette();
        }

        private void CalculateDistance()
        {
            if (!_catcherSpawner.HasPresenter(1)) return;

            _distance = Vector3.Distance(_playerSpawner.GetPresenter().transform.position, _catcherSpawner.GetPresenter(1).transform.position);
        }

        private void RefreshVignette()
        {
            _currentVignetteIntensity = (float)(_angle * _distance) + _offset;
            _postProcessService.ChangeVignetteIntensity(_currentVignetteIntensity);
        }


    }
}