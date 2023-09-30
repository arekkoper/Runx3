using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game.Commands.LoadLevel;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Presenters
{
    public class GoalStatic : MonoBehaviour
    {
        [Inject] private readonly SignalBus _signalBus;

        private void Awake()
        {
            DiContainer container = ProjectContext.Instance.Container;

            container.Inject(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            _signalBus.Fire(other);
        }
    }
}