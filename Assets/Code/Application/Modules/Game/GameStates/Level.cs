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
            Manager.Mediator.Send(new LoadLevelCommand());
        }
    }
}