
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Commons.Interfaces.Presenters;
using Assets.Code.Application.Modules.Hero.Behaviours;
using Assets.Code.Application.Modules.Hero.Commands.KillPlayer;
using Assets.Code.Application.Signals;
using Assets.Code.Domain.Entities;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Presenters
{
    public class PlayerPresenter : MonoBehaviour, IDieable
    {
        [Header("References")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _model;

        private PlayerMovementBehaviour _movementBehaviour;

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
        }

        private void Update()
        {
            _movementBehaviour.Behave();
        }

        public void Die()
        {
            _signalBus.Fire(new OnPlayerKilledSignal() { PlayerPresenter = this });
        }
    }
}