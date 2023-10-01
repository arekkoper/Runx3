using Assets.Code.Application.Modules.Game.Commands.LoadLevel;
using Assets.Code.Application.Modules.Hero.Commands.CreatePlayer;
using Assets.Code.Domain.Commons.Abstractions;

namespace Assets.Code.Application.Modules.Game.GameStates
{
    public class Level : GameState
    {
        public int LevelID { get; set; }

        public override void ReloadScenes()
        {
            ScenesToLoad.Add(Manager.UI_GAME);
            ScenesToLoad.Add(Manager.LEVELS[LevelID]);
            ScenesToUnload.Add(Manager.UI_MAIN_MENU);

            var previousLevelID = Manager.CurrentLevelID;

            previousLevelID--;

            if (previousLevelID > 0)
                ScenesToUnload.Add(Manager.LEVELS[previousLevelID]);
        }

        public override void UpdateState()
        {
        }

        public override void EnterState()
        {
            Manager.Mediator.Send(new LoadLevelCommand());
        }
    }
}