using Assets.Code.Application.Commons.Interfaces.Mediator;
using UnityEngine;

namespace Assets.Code.Application.Modules.Hero.Commands.DestroyPlayerPresenter
{
    public class DestroyPlayerPresenterCommandHandler : ICommandHandler<DestroyPlayerPresenterCommand>
    {
        public void Handle(DestroyPlayerPresenterCommand command)
        {
            Object.Destroy(command.PlayerPresenter.gameObject);
        }
    }
}