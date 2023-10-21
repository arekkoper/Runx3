using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Application.Modules.Level.Queries.GetLevel;

namespace Assets.Code.Application.Modules.Level.Commands.RunLevel
{
    public class RunLevelCommandHandler : ICommandHandler<RunLevelCommand>
    {
        private readonly IMediator _mediator;
        private readonly ILevelService _levelService;

        public RunLevelCommandHandler(IMediator mediator, ILevelService levelService)
        {
            _mediator = mediator;
            _levelService = levelService;
        }

        public void Handle(RunLevelCommand command)
        {
            var level = _mediator.Send(new GetLevelQuery() { Id = command.LevelID });
            var levels = _levelService.GetLevels();

            levels.ForEach(level => level.IsRunning = false);

            level.IsRunning = true;
        }
    }
}