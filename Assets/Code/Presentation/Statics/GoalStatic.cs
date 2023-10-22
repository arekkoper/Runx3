using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Hero.Commands.PlayerWin;
using Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Statics
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