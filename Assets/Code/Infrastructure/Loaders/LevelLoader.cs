using Assets.Code.Application.Modules.Enemies.Commands.UnspawnCatcher;
using Code.Application.Commons.Interfaces.Loaders;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Spawners;
using Code.Application.Signals;
using Code.Presentation.Spawners;
using Zenject;

namespace Code.Infrastructure.Loaders
{
    public class LevelLoader : ILevelLoader
    {
        private readonly IPlayerSpawner _playerSpawner;
        private readonly SignalBus _signalBus;
        private readonly IMediator _mediator;

        public LevelLoader(IPlayerSpawner playerSpawner, SignalBus signalBus, IMediator mediator)
        {
            _playerSpawner = playerSpawner;
            _signalBus = signalBus;
            _mediator = mediator;
        }

        public void Load(bool wasRestart) 
        {
            _playerSpawner.Spawn();

            _signalBus.Fire(new OnLevelLoadedSignal() 
            {
                PlayerPresenter = _playerSpawner.GetPresenter(),
                WasRestart = wasRestart
            });
        }

        public void Unload()
        {
            _playerSpawner.Unspawn();
            _mediator.Send(new UnspawnCatcherCommand());
        }
    }
}