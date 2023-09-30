using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game.GameStates;

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
            _gameManager.PreviousLevelID = _gameManager.CurentLevelID;
            _gameManager.CurentLevelID = command.LevelID;
            _gameManager.ChangeState(new Level() { LevelID = command.LevelID });

        }
    }
}