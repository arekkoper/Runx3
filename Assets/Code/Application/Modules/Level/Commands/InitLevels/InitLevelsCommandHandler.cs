using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Application.Modules.Level.Commands.MakeAvailable;

namespace Assets.Code.Application.Modules.Level.Commands.InitLevels
{
    public class InitLevelsCommandHandler : ICommandHandler<InitLevelsCommand>
    {
        private readonly ILevelService _levelService;
        private readonly IMediator _mediator;

        public InitLevelsCommandHandler(ILevelService levelService, IMediator mediator)
        {
            _levelService = levelService;
            _mediator = mediator;
        }

        public void Handle(InitLevelsCommand command)
        {
            for(int i = 0; i < command.LevelCap; i++)
            {
                _levelService.Create();
            }

            _mediator.Send(new MakeLevelAvailableCommand() { Id = 1 });
        }
    }
}