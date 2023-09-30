
using Assets.Code.Application.Commons.Interfaces.Loaders;
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game.GameStates;

namespace Assets.Code.Application.Modules.Game.Commands.ReturnToMenu
{
    public class ReturnToMenuCommandHandler : ICommandHandler<ReturnToMenuCommand>
    {
        private readonly GameManager _gameManager;
        private readonly ILevelLoader _levelLoader;

        public ReturnToMenuCommandHandler(GameManager gameManager, ILevelLoader levelLoader)
        {
            _gameManager = gameManager;
            _levelLoader = levelLoader;
        }

        public void Handle(ReturnToMenuCommand command)
        {
            _gameManager.ChangeState(new MainMenu());
        }
    }
}