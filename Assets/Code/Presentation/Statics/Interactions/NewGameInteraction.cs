
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game.Commands.ChangeGameState;
using Assets.Code.Presentation.Commons;
using Zenject;

namespace Assets.Code.Presentation.Statics.Interactions
{
    public class NewGameInteraction : MonoStatic
    {
        [Inject] private readonly IMediator _mediator;

        public void Interact()
        {
            _mediator.Send(new ChangeGameStateCommand() { LevelID = 1 });
        }
    }
}