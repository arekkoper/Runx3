
using Assets.Code.Application.Modules.Hero.Behaviours;
using Assets.Code.Domain.Entities;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Presenters
{
    public class PlayerPresenter : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _model;

        private PlayerMovementBehaviour _movementBehaviour;

        [Inject] private readonly Player _player;

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
    }
}