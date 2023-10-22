using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game.GameStates;

namespace Code.Application.Modules.Game.Commands.ReturnToMenu
{
    public class ReturnToMenuCommandHandler : ICommandHandler<ReturnToMenuCommand>
    {
        private readonly GameManager _gameManager;

        public ReturnToMenuCommandHandler(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void Handle(ReturnToMenuCommand command)
        {
            _gameManager.ChangeState(new MainMenuState());
        }
    }
}