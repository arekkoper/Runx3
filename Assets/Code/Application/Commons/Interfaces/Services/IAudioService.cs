using UnityEngine;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;

namespace Code.Application.Commons.Interfaces.Services
{
    public interface IAudioService
    {
        void ChangeAudioSourcePosition(Transform parent);
        void Configure(string name, AudioSettings settings);
        void DeleteAudioSource();
        void Play();
    }
}