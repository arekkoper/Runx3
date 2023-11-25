using Assets.Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Interfaces.Mediator;
using System;

namespace Assets.Code.Application.Modules.Game.Commands.Load
{
    public class LoadCommandHandler : ICommandHandler<LoadCommand>
    {
        private readonly ISavingService _savingService;

        public LoadCommandHandler(ISavingService savingService)
        {
            _savingService = savingService;
        }

        public void Handle(LoadCommand command)
        {
            _savingService.Load();
        }
    }
}
