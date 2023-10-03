
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Presentation.Presenters
{
    public class PiggerPresenter : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _pointsHub;
        [SerializeField] private Transform _model;

        [Header("Parameters")]
        [SerializeField] private float _speed;

        private const float RotationSlerpAmount = 0.05f;
        private int _currentPointIndex;
        private Transform _currentPoint;
        private Transform[] _points;

        public Transform[] Points { get => _points; }

        private void Start()
        {
            SetupPatrolPoints();
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
    }
}