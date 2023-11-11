using System;
using Code.Application.Signals;
using Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Components
{
    public class TriggerableComponent : MonoStatic
    {
        [Header("Parameters")] 
        [SerializeField] private string eventId;

        [Inject] private readonly SignalBus _signalBus;

        private void OnTriggerEnter(Collider other)
        {
            _signalBus.Fire(new OnTriggerActiveSignal(){ Id = eventId });
        }
    }
}