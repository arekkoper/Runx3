using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Hero.Commands.PlayerWin;
using Assets.Code.Application.Signals;
using Assets.Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Presenters
{
    public class GoalStatic : MonoStatic
    {
        [Inject] private readonly IMediator _mediator;

        private void OnTriggerEnter(Collider other)
        {
            _mediator.Send(new PlayerWinCommand());
        }
    }
}