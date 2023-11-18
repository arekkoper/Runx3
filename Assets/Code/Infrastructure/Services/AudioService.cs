using Assets.Code.Presentation.Factories;
using Code.Application.Commons.Interfaces.Services;
using UnityEngine;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;

namespace Code.Infrastructure.Services
{
    public class AudioService : IAudioService
    {
        private readonly AudioSourceFactory.Factory _audioSourceFactory;
        private readonly AudioSourceFactory _audioSource;

        public AudioService(AudioSourceFactory.Factory audioSourceFactory)
        {
            _audioSourceFactory = audioSourceFactory;

            _audioSource = _audioSourceFactory.Create();
        }

        public void ChangeAudioSourcePosition(Transform parent)
        {
            _audioSource.transform.SetParent(parent, false);
        }

        public void Configure(string name, AudioSettings settings)
        {
            _audioSource.name = name;
            _audioSource.Setup(settings);
        }

        public void DeleteAudioSource()
        {
            _audioSource.DeleteAudioSource();
        }

        public void Play()
        {
            _audioSource.Play();
        }
    }
}