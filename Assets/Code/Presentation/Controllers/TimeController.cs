using System;
using Code.Application.Signals;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Controllers
{
    public class TimeController : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        public TimeController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<OnInGameMenuOpenSignal>(StopTime);
            _signalBus.Subscribe<OnInGameMenuCloseSignal>(RunTime);
        }
        
        public void Dispose()
        {
            _signalBus.Unsubscribe<OnInGameMenuOpenSignal>(StopTime);
            _signalBus.Unsubscribe<OnInGameMenuCloseSignal>(RunTime);
        }
        
        private void StopTime()
        {
            Time.timeScale = 0f;
        }

        private void RunTime()
        {
            Time.timeScale = 1f;
        }


    }
}