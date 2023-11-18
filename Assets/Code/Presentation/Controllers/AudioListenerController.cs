using Assets.Code.Presentation.Factories;
using Code.Application.Signals;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Controllers
{
    public class AudioListenerController : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly AudioListenerFactory.Factory _audioListenerFactory;

        private AudioListenerFactory _audioListener;

        public AudioListenerController(SignalBus signalBus, AudioListenerFactory.Factory audioListenerFactory)
        {
            _signalBus = signalBus;
            _audioListenerFactory = audioListenerFactory;

            _audioListener = _audioListenerFactory.Create();
        }

        public void Initialize()
        {

            _signalBus.Subscribe<OnLevelLoadedSignal>(AttachToPlayer);
            _signalBus.Subscribe<OnReturnToMenuSignal>(AttachToOrigin);
            _signalBus.Subscribe<OnPlayerKilledSignal>(AttachToOrigin);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(AttachToPlayer);
            _signalBus.Unsubscribe<OnReturnToMenuSignal>(AttachToOrigin);
            _signalBus.Unsubscribe<OnPlayerKilledSignal>(AttachToOrigin);
        }

        private void AttachToPlayer(OnLevelLoadedSignal param)
        {
            _audioListener.transform.SetParent(param.PlayerPresenter.Model, false);
        }

        private void AttachToOrigin()
        {
            _audioListener.transform.SetParent(_audioListener.Parent, false);
        }

    }
}
