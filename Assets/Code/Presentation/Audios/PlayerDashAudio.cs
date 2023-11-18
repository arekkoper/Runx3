using System;
using Code.Application.Commons.Enums;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Structs;
using Code.Application.Signals;
using UnityEngine;
using Zenject;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;

namespace Code.Presentation.Audios
{
    public class PlayerDashAudio : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private AudioSettings settings;

        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly IAudioService _audioService;

        private void Start()
        {
            _audioService.ChangeAudioSourcePosition(transform);
            _audioService.Configure($"Audio (PlayerDash)", settings);
        }

        public void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerDashSignal>(Play);
        }

        public void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerDashSignal>(Play);
        }

        private void Play()
        {
            _audioService.Play();
        }
    }
}