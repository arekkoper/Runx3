
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Modules.Game.Commands.ChangeLevel;
using Assets.Code.Presentation.Commons;
using UnityEngine.UI;
using Zenject;

namespace Assets.Code.Presentation.Statics.Interactions
{
    public class ContinueGameInteraction : MonoStatic
    {
        [Inject] private readonly IMediator _mediator;
        [Inject] private readonly GameManager _gameManager;

        private void Start()
        {
            if (_gameManager.CurentLevelID == 0)
                GetComponent<Button>().interactable = false;
        }

        public void Interact()
        {
            _mediator.Send(new ChangeLevelCommand() { LevelID = _gameManager.CurentLevelID });
        }
    }
}