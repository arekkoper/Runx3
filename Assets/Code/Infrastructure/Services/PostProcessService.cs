
using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Application.Signals;
using Assets.Code.Presentation.Commons;
using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Zenject;

namespace Assets.Code.Infrastructure.Providers
{
    public class PostProcessService : MonoStatic, IPostProcessService
    {
        [Header("References")]
        [SerializeField] private Volume _volume;

        [Inject] private readonly SignalBus _signalBus;

        private Vignette Vignette { get => _volume.profile.TryGet(out Vignette vignette) ? vignette : null; }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnLevelLoadedSignal>(ResetVignette);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(ResetVignette);
        }

        private void ResetVignette()
        {
            ChangeVignetteIntensity(0f);
        }

        public void ChangeVignetteIntensity(float intensity)
        {
            Vignette.intensity.value = intensity;
        }
    }
}