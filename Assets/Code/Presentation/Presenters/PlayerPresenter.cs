using Code.Application.Commons.Interfaces.Presenters;
using Code.Application.Modules.Hero.Behaviours;
using Code.Application.Signals;
using Code.Domain.Entities;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Presenters
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
            _movementBehaviour.Behave();
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z); //I had to add this line, because player was "flying" on Y axis
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