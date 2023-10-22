using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game.Commands.ReturnToMenu;
using Code.Presentation.Commons;
using Zenject;

namespace Code.Presentation.Interactions
{
    public class ReturnToMainMenuInteraction : MonoStatic
    {
        [Inject] private readonly IMediator _mediator;

        public void Interact()
        {
            _mediator.Send(new ReturnToMenuCommand());
        }
    }
}