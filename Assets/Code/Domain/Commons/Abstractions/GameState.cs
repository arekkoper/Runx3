using Assets.Code.Infrastructure;
using System.Collections.Generic;

namespace Assets.Code.Domain.Commons.Abstractions
{
    public abstract class GameState
    {
        public GameManager Manager { get; set; }
        public List<string> ScenesToLoad { get; set; } = new();
        public List<string> ScenesToUnload { get; set; } = new();

        protected abstract void EnterState();
        public abstract void ReloadScenes();
        public abstract void UpdateState();
    }
}