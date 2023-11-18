using Code.Application.Commons.Interfaces.Services;
using Code.Presentation.Commons;
using UnityEngine;
using Zenject;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;

namespace Assets.Code.Presentation.Audios
{
    public class PiggerGrountingAudio : MonoStatic
    {
        [Header("Parameters")]
        [SerializeField] private AudioSettings settings;

        [Inject] private readonly IAudioService _audioService;

        private void Start()
        {
            _audioService.ChangeAudioSourcePosition(transform);
            _audioService.Configure($"Audio (PiggerGrounting/{name})", settings);

            _audioService.Play();
        }
    }
}
