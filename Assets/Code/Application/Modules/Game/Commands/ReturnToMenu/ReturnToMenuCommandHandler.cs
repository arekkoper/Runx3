
using Assets.Code.Application.Commons.Interfaces.Loaders;
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game.GameStates;

namespace Assets.Code.Application.Modules.Game.Commands.ReturnToMenu
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
            _gameManager.ChangeState(new MainMenu());
        }
    }
}