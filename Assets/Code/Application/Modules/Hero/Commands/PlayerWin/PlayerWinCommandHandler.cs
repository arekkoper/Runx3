using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Signals;
using Zenject;

namespace Assets.Code.Application.Modules.Hero.Commands.PlayerWin
{
    public class PlayerWinCommandHandler : ICommandHandler<PlayerWinCommand>
    {
        private readonly GameManager _gameManager;
        private readonly SignalBus _signalBus;
        private readonly IPlayerService _playerService;

        public PlayerWinCommandHandler(GameManager gameManager, SignalBus signalBus, IPlayerService playerService)
        {
            _gameManager = gameManager;
            _signalBus = signalBus;
            _playerService = playerService;
        }

        public void Handle(PlayerWinCommand command)
        {
            _playerService.IncreaseScore();

            _signalBus.Fire(new OnPlayerWinSignal()); //this is for UI

            _gameManager.CurrentLevelID++;

            _gameManager.Save();
            _playerService.Save();
       }
    }
}