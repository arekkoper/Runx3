using System.Collections.Generic;
using Code.Application.Signals;
using Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Presenters
{
    public class PiggerPresenter : MonoStatic
    {
        [Header("References")]
        [SerializeField] private Transform _pointsHub;
        [SerializeField] private Transform _model;

        [Header("Parameters")]
        [SerializeField] private float _speed;

        private const float RotationSlerpAmount = 0.08f;
        private int _currentPointIndex;
        private Transform _currentPoint;
        private Transform[] _points;

        [Inject] private readonly SignalBus _signalBus;

        public Transform[] Points { get => _points; }

        private void Start()
        {
            SetupPatrolPoints();
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnLevelLoadedSignal>(Restart);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(Restart);
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            if (_currentPoint != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);

                if (transform.position == _currentPoint.position)
                {
                    if (_currentPointIndex >= _points.Length - 1)
                    {
                        SetCurrentPoint(0);
                    }
                    else
                    {
                        SetCurrentPoint(_currentPointIndex + 1);
                    }
                }
                else
                {
                    Quaternion lookRotation = Quaternion.LookRotation(_currentPoint.position - transform.position);
                    _model.rotation = Quaternion.Slerp(_model.rotation, lookRotation, RotationSlerpAmount);
                }
            }
        }

        private void SetCurrentPoint(int index)
        {
            _currentPointIndex = index;
            _currentPoint = _points[index];
        }

        private void SetupPatrolPoints()
        {
            var points = GetUnsortedPatrolPoints();

            if(points.Count > 0)
            {
                _points = new Transform[points.Count];

                for(int i = 0; i < points.Count; i++)
                {
                    var point = points[i];
                    _points[i] = points[i];

                    point.SetParent(null);
                    point.gameObject.hideFlags = HideFlags.HideInHierarchy;
                }
            }
            else
            {
                _points = new Transform[0];
            }

            SetCurrentPoint(0);
        }

        public List<Transform> GetUnsortedPatrolPoints()
        {
            var points = new List<Transform>();

            for(int i = 0; i < _pointsHub.childCount; i++)
            {
                points.Add(_pointsHub.GetChild(i));
            }

            return points;
        }

        public void Restart()
        {
            SetCurrentPoint(0);
            transform.position = _points[0].position;
        }

    }
}