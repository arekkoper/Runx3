using System;
using Code.Application.Commons.Enums;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Structs;
using Code.Application.Signals;
using Zenject;

namespace Code.Presentation.Audios
{
    public class LightClickAudio : IInitializable, IDisposable
    {
        private readonly SignalBus _signal;
        private readonly IAudioService _audioService;

        public LightClickAudio(SignalBus signal, IAudioService audioService)
        {
            _signal = signal;
            _audioService = audioService;
        }
        
        public void Initialize()
        {
            _signal.Subscribe<OnButtonClick>(PlaySound);
        }

        public void Dispose()
        {
            _signal.Unsubscribe<OnButtonClick>(PlaySound);
        }
        
        private void PlaySound(OnButtonClick param)
        {
            var settings = new SoundSettings()
            {
                SoundType = param.IsHeavy ? SoundType.ClickHeavy : SoundType.ClickLight,
                Volume = 0.6f
            };
            
            _audioService.PlaySound(settings);
        }
    }
}