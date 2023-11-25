using System;
using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Application.Modules.Game.Commands.Save;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Hero.Commands.DestroyPlayerPresenter;
using Code.Application.Modules.Level.Commands.IncreaseDeathScore;
using Code.Application.Signals;
using Zenject;

namespace Code.Application.Observers
{
    public class OnPlayerKilledObserver : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IMediator _mediator;

        public OnPlayerKilledObserver(
            SignalBus signalBus,
            IMediator mediator
            )
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
            _mediator.Send(new DestroyPlayerPresenterCommand() { PlayerPresenter = param.PlayerPresenter });
            _mediator.Send(new IncreaseDeathScoreCommand());

            _mediator.Send(new SaveCommand());
        }
    }
}