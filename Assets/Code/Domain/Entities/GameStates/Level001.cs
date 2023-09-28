
using Assets.Code.Domain.Commons.Abstractions;

namespace Assets.Code.Domain.Entities.GameStates
{
    public class Level001 : GameState
    {
        public override void ReloadScenes()
        {
            ScenesToLoad.Add(Manager.UI_GAME);
            ScenesToLoad.Add(Manager.LEVEL_001);
            ScenesToUnload.Add(Manager.UI_MAIN_MENU);

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