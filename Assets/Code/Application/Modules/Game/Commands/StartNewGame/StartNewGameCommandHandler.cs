using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Modules.Game.Commands.ChangeLevel;

namespace Code.Application.Modules.Game.Commands.StartNewGame
{
    public class StartNewGameCommandHandler : ICommandHandler<StartNewGameCommand>
    {
        private readonly IMediator _mediator;
        private readonly IPlayerService _playerService;

        public StartNewGameCommandHandler(IMediator mediator, IPlayerService playerService)
        {
            _mediator = mediator;
            _playerService = playerService;
        }

        public void Handle(StartNewGameCommand command)
        {
            _playerService.ResetScore();

            _mediator.Send(new ChangeLevelCommand() { LevelID = 1 });
        }
    }
}