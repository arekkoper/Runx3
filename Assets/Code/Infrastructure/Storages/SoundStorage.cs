using Code.Application.Commons.Enums;
using Code.Application.Commons.Interfaces.Storages;
using SKUnityToolkit.SerializableDictionary;
using UnityEngine;

namespace Code.Infrastructure.Storages
{
    [CreateAssetMenu(fileName = "SoundStorage", menuName = "AQ/Storages/SoundStorage")]
    public class SoundStorage : ScriptableObject, ISoundStorage
    {
        [Header("Storages")] 
        [SerializeField] private SerializableDictionary<SoundType, AudioClip> soundDictionary;

        public AudioClip GetSound(SoundType type)
        {
            if (soundDictionary.TryGetValue(type, out AudioClip clip))
            {
                return clip;
            }
            else
            {
                Debug.LogError($"Sound {type} not found in dictionary");
                return null;
            }
        }
    }
    
}