﻿using System;
using Code.Application.Commons.Enums;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Structs;
using Code.Application.Signals;
using Zenject;

namespace Code.Presentation.Audios
{
    public class DashAudio : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IAudioService _audioService;

        public DashAudio(SignalBus signalBus, IAudioService audioService)
        {
            _signalBus = signalBus;
            _audioService = audioService;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<OnPlayerDashSignal>(PlaySound);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<OnPlayerDashSignal>(PlaySound);
        }

        private void PlaySound()
        {
            var settings = new SoundSettings()
            {
                SoundType = SoundType.PlayerDash,
                Volume = 0.1f
            };
            
            _audioService.PlaySound(settings);
        }
    }
}