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

        public PlayerWinCommandHandler(GameManager gameManager, SignalBus signalBus)
        {
            _gameManager = gameManager;
            _signalBus = signalBus;
        }

        public void Handle(PlayerWinCommand command)
        {
            _signalBus.Fire(new OnPlayerWinSignal()); //this is for UI

            //_gameManager.PreviousLevelID = _gameManager.CurrentLevelID;
            _gameManager.CurrentLevelID++;
            _gameManager.Save();
       }
    }
}