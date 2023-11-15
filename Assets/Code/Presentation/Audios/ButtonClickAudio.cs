using System;
using Code.Application.Commons.Interfaces.Services;
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

            _audioService.RenameAudioObject("Audio (ButtonClick)");
        }
        
        public void Initialize()
        {
            _signal.Subscribe<OnAudioSignal>(PlaySound);
        }

        public void Dispose()
        {
            _signal.Unsubscribe<OnAudioSignal>(PlaySound);
        }
        
        private void PlaySound(OnAudioSignal param)
        {
            _audioService.PlaySound(param.Settings);
        }
    }
}