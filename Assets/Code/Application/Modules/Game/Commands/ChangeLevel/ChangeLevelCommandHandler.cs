using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game.GameStates;
using Code.Application.Modules.Level.Commands.RunLevel;

namespace Code.Application.Modules.Game.Commands.ChangeLevel
{
    public class ChangeLevelCommandHandler : ICommandHandler<ChangeLevelCommand>
    {
        private readonly GameManager _gameManager;
        private readonly IMediator _mediator;

        public ChangeLevelCommandHandler(GameManager gameManager, IMediator mediator)
        {
            _gameManager = gameManager;
            _mediator = mediator;
        }

        public void Handle(ChangeLevelCommand command)
        {
            _mediator.Send(new RunLevelCommand() { LevelID = command.LevelID });

            _gameManager.ChangeState(new LevelState() { LevelID = command.LevelID });

        }
    }
}