using Assets.Code.Application.Signals;
using Assets.Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Presenters
{
    public class GoalStatic : MonoStatic
    {
        [Inject] private readonly SignalBus _signalBus;

        private void OnTriggerEnter(Collider other)
        {
            _signalBus.Fire(new OnPlayerWinSignal());
        }
    }
}