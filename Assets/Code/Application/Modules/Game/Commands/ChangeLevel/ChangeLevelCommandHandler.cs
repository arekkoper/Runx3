using Assets.Code.Application.Commons.Interfaces.Mediator;

namespace Assets.Code.Application.Modules.Game.Commands.ChangeLevel
{
    public class ChangeLevelCommandHandler : ICommandHandler<ChangeLevelCommand>
    {
        private readonly GameManager _gameManager;

        public ChangeLevelCommandHandler(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void Handle(ChangeLevelCommand command)
        {
            _gameManager.ChangeState(new GameStates.LevelState() { LevelID = command.LevelID });
        }
    }
}