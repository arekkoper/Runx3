using Assets.Code.Application.Signals;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Structs;
using Code.Presentation.Commons;
using System;
using Zenject;

namespace Assets.Code.Presentation.Audios
{
    public class SpikeTrapStickingOutAudio : MonoStatic
    {
        [UnityEngine.SerializeField] private AudioSettings settings;

        [Inject] private readonly IAudioService _audioService;
        [Inject] private readonly SignalBus _signalBus;

        private void Start()
        {
            _audioService.ChangeAudioSourcePosition(transform);
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnSpikeTrapStickingOutSignal>(PlaySound);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnSpikeTrapStickingOutSignal>(PlaySound);
        }

        private void PlaySound()
        {
            _audioService.Play(settings);
        }
    }
}