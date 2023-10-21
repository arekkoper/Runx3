using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Level.Queries.GetCurrentLevel;
using UnityEngine;

namespace Assets.Code.Application.Modules.Level.Commands.IncreaseDeathScore
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

            Debug.Log($"Level: {level.Id}, deaths: {level.Deaths}");
        }
    }
}