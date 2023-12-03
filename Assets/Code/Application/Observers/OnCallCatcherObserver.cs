using Assets.Code.Application.Modules.Enemies.Commands.SpawnCatcher;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Code.Application.Observers
{
    public class OnCallCatcherObserver : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IMediator _mediator;

        public OnCallCatcherObserver(SignalBus signalBus, IMediator mediator)
        {
            _signalBus = signalBus;
            _mediator = mediator;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<OnTriggerActiveSignal>(Perform);            
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<OnTriggerActiveSignal>(Perform);
        }

        private void Perform(OnTriggerActiveSignal param)
        {
            if (param.Id != "CallCatcher") return;

            _mediator.Send(new SpawnCatcherCommand());
        }

    }
}
