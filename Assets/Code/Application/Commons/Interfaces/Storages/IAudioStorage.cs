using UnityEngine;
using AudioType = Code.Application.Commons.Enums.AudioType;

namespace Code.Application.Commons.Interfaces.Storages
{
    public interface IAudioStorage
    {
        AudioClip GetSound(AudioType type);
    }
}