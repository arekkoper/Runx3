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

            if(LevelID-- <= 0)
                ScenesToUnload.Add(Manager.LEVELS[LevelID--]);

            EnterState();
        }

        public override void UpdateState()
        {
        }

        protected override void EnterState()
        {
            Manager.Mediator.Send(new LoadLevelCommand());
        }
    }
}