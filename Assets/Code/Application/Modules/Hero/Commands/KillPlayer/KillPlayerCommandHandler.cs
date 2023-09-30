using Assets.Code.Application.Commons.Interfaces.Mediator;
using UnityEngine;

namespace Assets.Code.Application.Modules.Hero.Commands.KillPlayer
{
    public class KillPlayerCommandHandler : ICommandHandler<KillPlayerCommand>
    {
        public void Handle(KillPlayerCommand command)
        {
            Object.Destroy(command.PlayerPresenter.gameObject);
        }
    }
}