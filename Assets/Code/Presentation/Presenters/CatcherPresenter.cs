
using Assets.Code.Application.Commons.Interfaces.Mediator;
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

        [Header("Parameters")]
        [SerializeField] private float _speed;
        [SerializeField] private float _minRetargetInterval;
        [SerializeField] private float _maxRetargetInterval;
        [SerializeField] private float _rotationTime;
        [SerializeField] private float _postRotationWaitTime;

        [Inject] private readonly PlayerSpawner _playerSpawner;

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
            _currentTarget = _playerSpawner.GetPlayerPosition();
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