using UnityEngine;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;

namespace Code.Application.Commons.Interfaces.Services
{
    public interface IAudioService
    {
        void ChangeAudioSourcePosition(Transform parent);
        void Play(AudioSettings settings);
        void PlaySound(AudioSettings settings);
        void RenameAudioObject(string name);
    }
}