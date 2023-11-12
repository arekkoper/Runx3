using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Interfaces.Storages;
using UnityEngine;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;
using AudioType = Code.Application.Commons.Enums.AudioType;

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
            _audioSource.volume = settings.Volume;
            _audioSource.clip = _audioStorage.GetSound(settings.AudioType);
            
            _audioSource.Play();
        }
    }
}