using System;
using Code.Application.Commons.Enums;

namespace Code.Application.Commons.Structs
{
    [Serializable]
    public struct AudioSettings
    {
        public AudioType AudioType { get; set; }
        public float Volume { get; set; }
        public bool IsLoop { get; set; }
        public float MaxDistance { get; set; }
        public float SpacialBlend { get; set; }
    }
}