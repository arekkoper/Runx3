using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game.Commands.ReturnToMenu;
using Code.Application.Signals;
using Code.Presentation.Commons;
using Zenject;

namespace Code.Presentation.Interactions
{
    public class ReturnToMainMenuInteraction : MonoStatic
    {
        [Inject] private readonly IMediator _mediator;
        [Inject] private readonly SignalBus _signalBus;

        public void Interact()
        {
            _signalBus.Fire(new OnReturnToMenuSignal());
            _mediator.Send(new ReturnToMenuCommand());
        }
    }
}