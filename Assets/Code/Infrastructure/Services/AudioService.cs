using Code.Application.Commons.Enums;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Interfaces.Storages;
using Code.Application.Commons.Structs;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public class AudioService : IAudioService
    {
        private readonly ISoundStorage _soundStorage;
        private readonly AudioSource _audioSource;
        
        public AudioService(ISoundStorage soundStorage)
        {
            _soundStorage = soundStorage;
            
            var audioObject = new GameObject();
            _audioSource = audioObject.AddComponent<AudioSource>();
        }
        
        public void PlaySound(SoundType type)
        {
            _audioSource.PlayOneShot(_soundStorage.GetSound(type));
        }

        public void PlaySound(SoundSettings settings)
        {
            _audioSource.volume = settings.Volume;
            _audioSource.clip = _soundStorage.GetSound(settings.SoundType);
            
            _audioSource.Play();
        }
    }
}