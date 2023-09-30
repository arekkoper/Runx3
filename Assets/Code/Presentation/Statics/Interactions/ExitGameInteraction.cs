using Assets.Code.Application.Modules.Game;
using Assets.Code.Presentation.Commons;
using Zenject;

namespace Assets.Code.Presentation.Statics.Interactions
{
    public class ExitGameInteraction : MonoStatic
    {
        [Inject] private readonly GameManager _gameManager;

        public void Interact()
        {
            _gameManager.Save();

            UnityEngine.Application.Quit();
        }
    }
}