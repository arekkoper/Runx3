using Code.Application.Commons.Interfaces.Storages;
using SKUnityToolkit.SerializableDictionary;
using UnityEngine;
using AudioType = Code.Application.Commons.Enums.AudioType;

namespace Code.Infrastructure.Storages
{
    [CreateAssetMenu(fileName = "AudioStorage", menuName = "AQ/Storages/AudioStorage")]
    public class AudioStorage : ScriptableObject, IAudioStorage
    {
        [Header("Storage")] 
        [SerializeField] private SerializableDictionary<AudioType, AudioClip> audioDictionary;

        public AudioClip GetClip(AudioType type)
        {
            if (audioDictionary.TryGetValue(type, out AudioClip clip))
            {
                return clip;
            }

            Debug.LogError($"Audio with type: {type}, not found in audio storage file. Please update the file in Resources/Storages.");
            return null;
        }
    }
    
}