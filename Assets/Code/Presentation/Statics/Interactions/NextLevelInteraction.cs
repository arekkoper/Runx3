
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Modules.Game.Commands.ChangeLevel;
using Assets.Code.Presentation.Commons;
using Zenject;

namespace Assets.Code.Presentation.Statics.Interactions
{
    public class NextLevelInteraction : MonoStatic
    {
        [Inject] private readonly IMediator _mediator;
        [Inject] private readonly GameManager _gameManager;

        public void Interact()
        {
            var newLevelID = _gameManager.CurentLevelID;
            newLevelID++;
            _mediator.Send(new ChangeLevelCommand() { LevelID = newLevelID });
        }
    }
}