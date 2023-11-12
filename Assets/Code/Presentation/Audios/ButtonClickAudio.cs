using System;
using Code.Application.Commons.Enums;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Structs;
using Code.Application.Signals;
using Zenject;

namespace Code.Presentation.Audios
{
    public class ButtonClickAudio : IInitializable, IDisposable
    {
        private readonly SignalBus _signal;
        private readonly IAudioService _audioService;

        public ButtonClickAudio(SignalBus signal, IAudioService audioService)
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
            var settings = new AudioSettings()
            {
                AudioType = param.AudioType,
                Volume = 0.6f
            };
            
            _audioService.PlaySound(settings);
        }
    }
}