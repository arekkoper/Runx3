using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Level.Queries.AreAllLevelsAvailable;
using Code.Application.Modules.Level.Queries.GetLevel;

namespace Code.Application.Modules.Level.Commands.MakeAvailable
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
            if (_mediator.Send(new AreAllLevelsAvailableQuery())) return;
            
            var level = _mediator.Send(new GetLevelQuery() { Id = command.Id });

            level.IsAvailable = true;
        }
    }
}