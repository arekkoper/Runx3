using Assets.Code.Application.Modules.Game.Commands.UnloadLevel;
using Assets.Code.Domain.Commons.Abstractions;

namespace Assets.Code.Application.Modules.Game.GameStates
{
    public class MainMenu : GameState
    {
        public override void ReloadScenes()
        {
            ScenesToLoad.Add(Manager.UI_MAIN_MENU);
            ScenesToUnload.Add(Manager.UI_GAME);

            if(Manager.CurentLevelID > 0)
                ScenesToUnload.Add(Manager.LEVELS[Manager.CurentLevelID]);
        }

        public override void UpdateState()
        {
        }

        public override void EnterState()
        {
            Manager.Mediator.Send(new UnloadLevelCommand());
        }
    }
}