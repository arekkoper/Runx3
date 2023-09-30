
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Hero.Commands.KillPlayer;
using Assets.Code.Application.Signals;
using System;
using Zenject;

namespace Assets.Code.Application.Observers
{
    public class OnPlayerKilledObserver : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IMediator _mediator;

        public OnPlayerKilledObserver(SignalBus signalBus, IMediator mediator)
        {
            _signalBus = signalBus;
            _mediator = mediator;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<OnPlayerKilledSignal>(Perform);
        }
        public void Dispose()
        {
            _signalBus.Unsubscribe<OnPlayerKilledSignal>(Perform);
        }

        private void Perform(OnPlayerKilledSignal param)
        {
            _mediator.Send(new KillPlayerCommand() { PlayerPresenter = param.PlayerPresenter });
        }
    }
}