﻿using Code.Application.Commons.Interfaces.Presenters;
using Code.Application.Modules.Hero.Behaviours;
using Code.Application.Signals;
using Code.Domain.Entities;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Presenters
{
    public class PlayerPresenter : MonoBehaviour, IDieable, IPickable
    {
        [Header("References")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _model;
        [SerializeField] private AudioSource dashSound;

        public PlayerDashBehaviour DashBehaviour => _dashBehaviour;
        public Transform Model => _model;
        
        private PlayerMovementBehaviour _movementBehaviour;
        private PlayerDashBehaviour _dashBehaviour;

        [Inject] private readonly Player _player;
        [Inject] private readonly SignalBus _signalBus;

        public class Factory : PlaceholderFactory<Player, PlayerPresenter> { }

        private void Start()
        {
            _movementBehaviour = new PlayerMovementBehaviour()
            {
                CharacterController = _characterController,
                Speed = _player.Speed,
                VelocityGain = _player.VelocityGainPerSecond,
                VelocityLoss = _player.VelocityLossPerSecond,
                ReverseMomentum = _player.ReverseMomentumMultiplier,
                Model = _model
            };

            _dashBehaviour = new PlayerDashBehaviour()
            {
                CharacterController = _characterController,
                MovementVelocity = _movementBehaviour.MovementVelocity,
                Model = _model,
                Speed = _player.Speed,
                SignalBus = _signalBus
            };
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerWinSignal>(React);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerWinSignal>(React);
        }

        private void Update()
        {
            if(!_dashBehaviour.IsDashing)
                _movementBehaviour.Behave();
            
            _dashBehaviour.Behave();
            
            transform.position = new Vector3(transform.position.x, 5.13f, transform.position.z); //I had to add this line, because player was "flying" on Y axis
        }

        private void React()
        {
            _movementBehaviour.StopHandleInputs = true;
        }

        public void Die()
        {
            _signalBus.Fire(new OnPlayerKilledSignal() { PlayerPresenter = this });
        }
    }
}