﻿using UnityEngine;

namespace Assets.Code.Domain.Entities
{
    public class Level
    {
        public int Id { get; set; }
        public int TheBestScore { get; set; }
        public int Deaths { get; set; }
        public bool IsAvailable { get; set; }
        public Sprite Thumbnail { get; set; }
    }
}