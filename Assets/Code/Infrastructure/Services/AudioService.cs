using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Interfaces.Storages;
using UnityEngine;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;

namespace Code.Infrastructure.Services
{
    public class AudioService : IAudioService
    {
        private readonly IAudioStorage _audioStorage;
        private readonly AudioSource _audioSource;

        public AudioService(IAudioStorage audioStorage)
        {
            _audioStorage = audioStorage;
            
            var audioObject = new GameObject
            {
                name = "AudioSource"
            };
            
            _audioSource = audioObject.AddComponent<AudioSource>();
        }

        public void PlaySound(AudioSettings settings)
        {
            _audioSource.clip = _audioStorage.GetSound(settings.AudioType);
            _audioSource.volume = settings.Volume;
            _audioSource.loop = settings.IsLoop;
            _audioSource.maxDistance = settings.MaxDistance;
            _audioSource.spatialBlend = settings.SpacialBlend;
            _audioSource.rolloffMode = AudioRolloffMode.Linear;
            
            _audioSource.Play();
        }

        public void Play(AudioSettings settings)
        {
            _audioSource.clip = settings.clip;
            _audioSource.volume = settings.volume;
            _audioSource.loop = settings.isLoop;
            _audioSource.maxDistance = settings.maxDistance;
            _audioSource.spatialBlend = settings.spacialBlend;
            _audioSource.rolloffMode = settings.mode;
            _audioSource.playOnAwake = settings.playOnAwake;

            _audioSource.Play();
        }

        public void RenameAudioObject(string name)
        {
            _audioSource.name = name;
        }

        public void ChangeAudioSourcePosition(Transform parent)
        {
            _audioSource.transform.SetParent(parent, false);
        }

    }
}