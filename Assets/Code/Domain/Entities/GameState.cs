using System.Collections.Generic;
using Code.Application.Modules.Game;

namespace Code.Domain.Entities
{
    public abstract class GameState
    {
        public GameManager Manager { get; set; }
        public List<string> ScenesToLoad { get; set; } = new();
        public List<string> ScenesToUnload { get; set; } = new();

        public abstract void EnterState();
        public abstract void ReloadScenes();
        public abstract void UpdateState();
    }
}