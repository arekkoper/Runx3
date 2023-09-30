using Assets.Code.Domain.Commons.Abstractions;

namespace Assets.Code.Application.Modules.Game.GameStates
{
    public class MainMenu : GameState
    {
        public override void ReloadScenes()
        {
            ScenesToLoad.Add(Manager.UI_MAIN_MENU);
            ScenesToUnload.Add(Manager.UI_GAME);

            EnterState();
        }

        public override void UpdateState()
        {
        }

        protected override void EnterState()
        {

        }
    }
}