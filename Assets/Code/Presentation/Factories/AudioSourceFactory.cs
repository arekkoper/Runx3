using System;
using UnityEngine;
using Zenject;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;

namespace Assets.Code.Presentation.Factories
{
    public class AudioSourceFactory : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private AudioSource _audioSource;

        public class Factory : PlaceholderFactory<AudioSourceFactory> { }

        public void Setup(AudioSettings settings)
        {
            _audioSource.clip = settings.clip;
            _audioSource.volume = settings.volume;
            _audioSource.loop = settings.isLoop;
            _audioSource.maxDistance = settings.maxDistance;
            _audioSource.spatialBlend = settings.spacialBlend;
            _audioSource.rolloffMode = settings.mode;
            _audioSource.playOnAwake = settings.playOnAwake;
        }

        public void Play()
        {
            _audioSource.Play();
        }

        public void DeleteAudioSource()
        {
            Invoke(nameof(Delete), _audioSource.clip.length);
        }

        private void Delete()
        {
            Destroy(gameObject);
        }
    }
}
