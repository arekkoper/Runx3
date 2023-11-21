﻿using Assets.Code.Application.Signals;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Structs;
using Code.Presentation.Commons;
using Code.Presentation.Presenters;
using System;
using UnityEngine;
using Zenject;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;

namespace Assets.Code.Presentation.Audios
{
    public class SpikeTrapStickingOutAudio : MonoStatic
    {
        [Header("Parameters")]
        [SerializeField] private AudioSettings settings;

        [Inject] private readonly IAudioService _audioService;
        [Inject] private readonly SignalBus _signalBus;

        [SerializeField] private string _eventId;

        private void Start()
        {
            _eventId = GetComponentInParent<SpikeTrapPresenter>().name;
            _audioService.Configure($"Audio (SpikeTrapStickingOut)", settings, transform);
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnSpikeTrapStickingOutSignal>(PlaySound);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnSpikeTrapStickingOutSignal>(PlaySound);
        }

        private void PlaySound(OnSpikeTrapStickingOutSignal param)
        {
            if (_eventId != param.Id) return;

            _audioService.Play();
        }
    }
}