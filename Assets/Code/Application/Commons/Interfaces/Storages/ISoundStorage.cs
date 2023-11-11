using Code.Application.Commons.Enums;
using UnityEngine;

namespace Code.Application.Commons.Interfaces.Storages
{
    public interface ISoundStorage
    {
        AudioClip GetSound(SoundType type);
    }
}