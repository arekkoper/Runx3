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

            foreach (var item in Manager.LEVELS)
            {
                ScenesToUnload.Add(Manager.LEVELS[item.Key]);
            }

            //if (Manager.CurrentLevelID > 0)
            //    ScenesToUnload.Add(Manager.LEVELS[Manager.CurrentLevelID]);
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