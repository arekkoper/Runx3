using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Level.Queries.GetCurrentLevel;

namespace Code.Application.Modules.Level.Commands.IncreaseDeathScore
{
    public class IncreaseDeathScoreCommandHandler : ICommandHandler<IncreaseDeathScoreCommand>
    {
        private readonly IMediator _mediator;

        public IncreaseDeathScoreCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Handle(IncreaseDeathScoreCommand command)
        {
            var level = _mediator.Send(new GetCurrentLevelCommand());

            level.Deaths++;

        }
    }
}