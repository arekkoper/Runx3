
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game.Commands.ChangeLevel;

namespace Assets.Code.Application.Modules.Game.Commands.StartNewGame
{
    public class StartNewGameCommandHandler : ICommandHandler<StartNewGameCommand>
    {
        private readonly IMediator _mediator;
        private readonly IPlayerService _playerService;
        private readonly GameManager _gameManager;

        public StartNewGameCommandHandler(IMediator mediator, IPlayerService playerService, GameManager gameManager)
        {
            _mediator = mediator;
            _playerService = playerService;
            _gameManager = gameManager;
        }

        public void Handle(StartNewGameCommand command)
        {
            _playerService.ResetScore();
            _gameManager.CurrentLevelID = 1;
            _gameManager.Save();
            _mediator.Send(new ChangeLevelCommand() { LevelID = 1 });
        }
    }
}