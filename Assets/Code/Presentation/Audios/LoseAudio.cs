using Code.Application.Commons.Interfaces.Services;
using System;
using AudioType = Code.Application.Commons.Enums.AudioType;
using Zenject;
using Code.Application.Commons.Structs;
using Code.Application.Signals;

namespace Assets.Code.Presentation.Audios
{
    public class LoseAudio : IInitializable, IDisposable
    {
        private AudioSettings _settings = new AudioSettings()
        {
            audioType = AudioType.Lose,
            playOnAwake = false,
            isLoop = false,
            maxDistance = 10,
            mode = UnityEngine.AudioRolloffMode.Logarithmic,
            spacialBlend = 0,
            volume = 0.5f
        };

        private readonly IAudioService _audioService;
        private readonly SignalBus _signalBus;

        public LoseAudio(
            IAudioService audioService,
            SignalBus signalBus
        ){
            _audioService = audioService;
            _signalBus = signalBus;

            _audioService.Configure("Audio (Lose)", _settings);

        }

        public void Initialize()
        {
            _signalBus.Subscribe<OnPlayerKilledSignal>(Play);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<OnPlayerKilledSignal>(Play);
        }

        private void Play()
        {
            _audioService.Play();
        }
    }
}
