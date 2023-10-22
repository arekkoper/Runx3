﻿using Code.Application.Signals;
using Code.Presentation.Commons;
using Code.Presentation.Spawners;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Presenters
{
    public class CatcherPresenter : MonoStatic
    {
        [Header("References")]
        [SerializeField] private Transform _model;

        [Header("Parameters")]
        [SerializeField] private float _speed;
        [SerializeField] private float _minRetargetInterval;
        [SerializeField] private float _maxRetargetInterval;
        [SerializeField] private float _rotationTime;
        [SerializeField] private float _postRotationWaitTime;

        [Inject] private readonly PlayerSpawner _playerSpawner;
        [Inject] private readonly SignalBus _signalBus;

        public class Factory : PlaceholderFactory<CatcherPresenter> { }

        private enum State
        {
            Idle,
            Rotating,
            Moving
        }

        private State _state = State.Idle;
        private Vector3 _currentTarget;
        private Quaternion _initialRotation;
        private Quaternion _targetRotation;
        private float _rotationStartTime;

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
            if(_state == State.Moving)
            {
                var delta = _speed * Time.deltaTime;
                
                transform.position = Vector3.MoveTowards(transform.position, _currentTarget, delta);

                if(transform.position == _currentTarget)
                {
                    _state = State.Idle;
                    Invoke("Retarget", UnityEngine.Random.Range(_minRetargetInterval, _maxRetargetInterval));
                }
            }
            else if(_state == State.Rotating)
            {
                var timeSpentRotating = Time.time - _rotationStartTime;
                _model.rotation = Quaternion.Slerp(_initialRotation, _targetRotation, timeSpentRotating / _rotationTime);
            }
        }

        private void Retarget()
        {
            _currentTarget = _playerSpawner.HasPresenter() ? _playerSpawner.GetPlayerPosition() : new Vector3(transform.position.x + 2f, 0f, transform.position.z + 2f);
            _initialRotation = _model.rotation;
            _targetRotation = Quaternion.LookRotation((_currentTarget - transform.position).normalized);
            _state = State.Rotating;
            _rotationStartTime = Time.time;
            Invoke("BeginMoving", _rotationTime + _postRotationWaitTime);
        }

        private void BeginMoving()
        {
            _model.rotation = _targetRotation;
            _state = State.Moving;
        }
    }
}