using Code.Application.Modules.Game.Commands.LoadLevel;
using Code.Domain.Entities;
using UnityEngine;

namespace Code.Application.Modules.Game.GameStates
{
    public class LevelState : GameState
    {
        public int LevelID { get; set; }
        public bool WasRestart { get; set; }

        public override void ReloadScenes()
        {
            ScenesToLoad.Add(Manager.UI_GAME);
            ScenesToLoad.Add(Manager.LEVELS[LevelID]);
            ScenesToUnload.Add(Manager.UI_MAIN_MENU);

            foreach (var item in Manager.LEVELS)
            {
                ScenesToUnload.Add(Manager.LEVELS[item.Key]);
            }

        }

        public override void UpdateState()
        {
        }

        public override void EnterState()
        {
            Manager.Mediator.Send(new LoadLevelCommand() { WasRestart = WasRestart });
            Manager.StartLevelTime = Time.time;

        }

    }
}