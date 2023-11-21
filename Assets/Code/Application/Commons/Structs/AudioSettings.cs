using System;
using UnityEngine;

namespace Code.Application.Commons.Structs
{
    [Serializable]
    public struct AudioSettings
    {
        public Enums.AudioType audioType;
        public AudioRolloffMode mode;
        [Range(0, 1)] public float volume;
        [Range(0, 100)] public float maxDistance;
        [Range(0, 1)] public float spacialBlend;
        public bool isLoop;
        public bool playOnAwake;
    }
}