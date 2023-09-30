
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Modules.Game.Commands.ReturnToMenu;
using Assets.Code.Presentation.Commons;
using Zenject;

namespace Assets.Code.Presentation.Statics.Interactions
{
    public class ReturnToMainMenuInteraction : MonoStatic
    {
        [Inject] private readonly IMediator _mediator;
        [Inject] private readonly GameManager _gameManager;

        public void Interact()
        {
            _gameManager.Save();
            _mediator.Send(new ReturnToMenuCommand());
        }
    }
}