using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Interfaces.Spawners;
using Code.Application.Commons.Structs;
using Code.Application.Signals;
using System;
using Zenject;
using AudioType = Code.Application.Commons.Enums.AudioType;

namespace Assets.Code.Presentation.Controllers
{
    public class MusicController : IInitializable, IDisposable
    {
        private AudioSettings settings = new AudioSettings()
        {
            audioType = AudioType.MusicMainMenu,
            playOnAwake = true,
            isLoop = true,
            maxDistance = 100,
            mode = UnityEngine.AudioRolloffMode.Linear,
            volume = 0.3f,
            spacialBlend = 0
        };

        private readonly SignalBus _signalBus;
        private readonly IAudioService _audioService;

        public MusicController(
            SignalBus signalBus,
            IAudioService audioService
        ){
            _signalBus = signalBus;
            _audioService = audioService;
        }

        public void Initialize()
        {
            _audioService.Configure($"Audio (Music)", settings);
            _audioService.Play();

            _signalBus.Subscribe<OnLevelLoadedSignal>(SwitchToLevelMusic);
            _signalBus.Subscribe<OnReturnToMenuSignal>(SwitchToMainMusic);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(SwitchToLevelMusic);
            _signalBus.Unsubscribe<OnReturnToMenuSignal>(SwitchToMainMusic);
        }

        private void SwitchToMainMusic()
        {
            settings.audioType = AudioType.MusicMainMenu;

            Reconfigure();
        }


        private void SwitchToLevelMusic(OnLevelLoadedSignal param)
        {
            if (param.WasRestart) return;

            settings.audioType = AudioType.MusicLevel;

            Reconfigure();
        }

        private void Reconfigure()
        {
            _audioService.Reconfigure(settings);
            _audioService.Play();
        }


    }
}
