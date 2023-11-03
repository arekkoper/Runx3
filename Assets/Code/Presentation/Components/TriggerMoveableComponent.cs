using System;
using System.Collections;
using Code.Application.Signals;
using Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Components
{
    public class TriggerMoveableComponent : MonoStatic
    {
        [Header("References")] 
        [SerializeField] private Transform model;

        [Header("Parameters")] 
        [SerializeField] private string eventId;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float speed;

        [Inject] private readonly SignalBus _signalBus;

        private Vector3 _targetPosition;
        private bool _isActive;

        private void Start()
        {
            _targetPosition = model.position + offset;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnTriggerActiveSignal>(React);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnTriggerActiveSignal>(React);
        }

        private void React(OnTriggerActiveSignal param)
        {
            if (param.Id != eventId && !_isActive) return;

            _isActive = true;
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (Vector3.Distance(model.position, _targetPosition) >= 0.1f)
            {
                model.position = Vector3.MoveTowards(model.position, _targetPosition, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}