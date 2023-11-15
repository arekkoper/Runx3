using System;
using Code.Application.Commons.Enums;
using UnityEngine;

namespace Code.Application.Commons.Structs
{
    [Serializable]
    public struct AudioSettings
    {
        public Enums.AudioType AudioType { get; set; }
        public float Volume { get; set; }
        public bool IsLoop { get; set; }
        public float MaxDistance { get; set; }
        public float SpacialBlend { get; set; }

        //new fields
        public AudioClip clip;
        public AudioRolloffMode mode;
        [Range(0, 1)] public float volume;
        [Range(0, 100)] public float maxDistance;
        [Range(0, 1)] public float spacialBlend;
        public bool isLoop;
        public bool playOnAwake;
    }
}