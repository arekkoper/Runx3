using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Structs;
using Code.Application.Signals;
using System;
using Zenject;
using AudioType = Code.Application.Commons.Enums.AudioType;

namespace Assets.Code.Presentation.Audios
{
    public class WinAudio : IInitializable, IDisposable
    {
        private AudioSettings _settings = new AudioSettings()
        {
            audioType = AudioType.Win,
            playOnAwake = false,
            isLoop = false,
            maxDistance = 10,
            mode = UnityEngine.AudioRolloffMode.Logarithmic,
            spacialBlend = 0,
            volume = 0.5f
        };

        private readonly IAudioService _audioService;
        private readonly SignalBus _signalBus;

        public WinAudio(
            IAudioService audioService,
            SignalBus signalBus
        ){
            _audioService = audioService;
            _signalBus = signalBus;

            _audioService.Configure("Audio (Win)", _settings);
        }

        public void Initialize()
        {
            _signalBus.Subscribe<OnPlayerWinSignal>(Play);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<OnPlayerWinSignal>(Play);
        }

        private void Play()
        {
            _audioService.Play();
        }

    }
}
