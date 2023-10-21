
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Commons.Interfaces.Services;

namespace Assets.Code.Application.Modules.Catcher.Commands.CreateCatcher
{
    public class CreateCatcherCommandHandler : ICommandHandler<CreateCatcherCommand, Domain.Entities.Catcher>
    {
        private readonly ICatcherService _catcherService;

        public CreateCatcherCommandHandler(ICatcherService catcherService)
        {
            _catcherService = catcherService;
        }

        public Domain.Entities.Catcher Handle(CreateCatcherCommand command)
        {
            return _catcherService.Create();
        }
    }
}