using Assets.Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Interfaces.Mediator;

namespace Assets.Code.Application.Modules.Game.Commands.Save
{
    public class SaveCommandHandler : ICommandHandler<SaveCommand>
    {
        private readonly ISavingService _savingService;

        public SaveCommandHandler(ISavingService savingService)
        {
            _savingService = savingService;
        }

        public void Handle(SaveCommand command)
        {
            _savingService.Save();
        }
    }
}
