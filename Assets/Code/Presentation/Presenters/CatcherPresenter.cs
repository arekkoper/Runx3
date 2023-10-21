
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Signals;
using Assets.Code.Domain.Entities;
using Assets.Code.Domain.Enums;
using Assets.Code.Presentation.Commons;
using Assets.Code.Presentation.Spawners;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Presenters
{
    public class CatcherPresenter : MonoStatic
    {
        [Header("References")]
        [SerializeField] private Transform _model;

        //[Header("Parameters")]
        //[SerializeField] private float _speed;
        //[SerializeField] private float _minRetargetInterval;
        //[SerializeField] private float _maxRetargetInterval;
        //[SerializeField] private float _rotationTime;
        //[SerializeField] private float _postRotationWaitTime;

        [Inject] private readonly PlayerSpawner _playerSpawner;
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly Catcher _catcher;

        public class Factory : PlaceholderFactory<Catcher, CatcherPresenter> { }

        //private enum State
        //{
        //    Idle,
        //    Rotating,
        //    Moving
        //}

        //private State _state = State.Idle;
        //private Vector3 _currentTarget;
        //private Quaternion _initialRotation;
        //private Quaternion _targetRotation;
        //private float _rotationStartTime;

        private void Start()
        {
            Retarget();
        }

        private void Update()
        {
            Movement();
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerWinSignal>(React);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerWinSignal>(React);
        }

        private void React()
        {
            gameObject.SetActive(false);
        }

        private void Movement()
        {
            if(_catcher.State == CatcherState.Moving)
            {
                var delta = _catcher.Speed * Time.deltaTime;
                
                transform.position = Vector3.MoveTowards(transform.position, _catcher.CurrentTarget, delta);

                if(transform.position == _catcher.CurrentTarget)
                {
                    _catcher.State = CatcherState.Idle;
                    Invoke("Retarget", UnityEngine.Random.Range(_catcher.MinRetargetInterval, _catcher.MaxRetargetInterval));
                }
            }
            else if(_catcher.State == CatcherState.Rotating)
            {
                var timeSpentRotating = Time.time - _catcher.RotationStartTime;
                _model.rotation = Quaternion.Slerp(_catcher.InitialRotation, _catcher.TargetRotation, timeSpentRotating / _catcher.RotationTime);
            }
        }

        private void Retarget()
        {
            _catcher.CurrentTarget = _playerSpawner.HasPresenter() ? _playerSpawner.GetPlayerPosition() : new Vector3(transform.position.x + 2f, 0f, transform.position.z + 2f);
            _catcher.InitialRotation = _model.rotation;
            _catcher.TargetRotation = Quaternion.LookRotation((_catcher.CurrentTarget - transform.position).normalized);
            _catcher.State = CatcherState.Rotating;
            _catcher.RotationStartTime = Time.time;
            Invoke("BeginMoving", _catcher.RotationTime + _catcher.PostRotationWaitTime);
        }

        private void BeginMoving()
        {
            _model.rotation = _catcher.TargetRotation;
            _catcher.State = CatcherState.Moving;
        }
    }
}