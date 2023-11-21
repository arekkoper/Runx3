using Assets.Code.Application.Signals;
using Code.Application.Commons.Interfaces.Services;
using Code.Presentation.Commons;
using Code.Presentation.Presenters;
using UnityEngine;
using Zenject;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;

namespace Assets.Code.Presentation.Audios
{
    public class TowerShootAudio : MonoStatic
    {
        [Header("Parameters")]
        [SerializeField] private AudioSettings settings;
        
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly IAudioService _audioService;
        
        private string _towerId;

        private void Start()
        {
            _towerId = GetComponentInParent<ShooterPresenter>().name;
            _audioService.Configure($"Audio (Shoot)", settings, transform);
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnTowerShootSignal>(Play);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnTowerShootSignal>(Play);
        }

        private void Play(OnTowerShootSignal param)
        {
            if (param.Id != _towerId) return;

            _audioService.Play();
        }
    }
}
