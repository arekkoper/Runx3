using System;
using UnityEngine;

namespace Code.Domain.Entities
{
    [Serializable]
    public class Level
    {
        public int Id { get; set; }
        public float TheBestScore { get; set; }
        public int Deaths { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsRunning { get; set; }
        public string ThumbnailPath { get; set; }
    }
}