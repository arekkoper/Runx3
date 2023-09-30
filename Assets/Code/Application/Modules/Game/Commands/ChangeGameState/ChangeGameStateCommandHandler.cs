
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game.GameStates;

namespace Assets.Code.Application.Modules.Game.Commands.ChangeGameState
{
    public class ChangeGameStateCommandHandler : ICommandHandler<ChangeGameStateCommand>
    {
        private readonly GameManager _gameManager;

        public ChangeGameStateCommandHandler(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void Handle(ChangeGameStateCommand command)
        {
            _gameManager.ChangeState(new Level() { LevelID = command.LevelID });
        }
    }
}