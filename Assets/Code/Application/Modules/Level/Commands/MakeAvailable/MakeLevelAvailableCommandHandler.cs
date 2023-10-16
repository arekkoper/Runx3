
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Level.Queries.GetLevel;

namespace Assets.Code.Application.Modules.Level.Commands.MakeAvailable
{
    public class MakeLevelAvailableCommandHandler : ICommandHandler<MakeLevelAvailableCommand>
    {
        private readonly IMediator _mediator;

        public MakeLevelAvailableCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Handle(MakeLevelAvailableCommand command)
        {
            var level = _mediator.Send(new GetLevelQuery() { Id = command.Id });

            level.IsAvailable = true;
        }
    }
}