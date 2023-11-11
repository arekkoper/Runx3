using Code.Application.Commons.Enums;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Interfaces.Storages;
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
    }
}