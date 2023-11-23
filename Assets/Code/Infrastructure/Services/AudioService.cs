using Assets.Code.Presentation.Factories;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Interfaces.Storages;
using UnityEngine;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;
using AudioType = Code.Application.Commons.Enums.AudioType;

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

        public void Configure(string name, AudioSettings settings, Transform parent = null)
        {
            if (parent)
                ChangeAudioSourcePosition(parent);

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

        public void Reconfigure(AudioSettings settings)
        {
            _audioSource.Setup(settings);
        }
    }
}