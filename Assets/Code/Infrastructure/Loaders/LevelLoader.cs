using Code.Application.Commons.Interfaces.Loaders;
using Code.Application.Commons.Interfaces.Spawners;
using Code.Application.Signals;
using Code.Presentation.Spawners;
using Zenject;

namespace Code.Infrastructure.Loaders
{
    public class LevelLoader : ILevelLoader
    {
        private readonly PlayerSpawner _playerSpawner;
        private readonly ICatcherSpawner _catcherSpawner;
        private readonly SignalBus _signalBus;

        public LevelLoader(PlayerSpawner playerSpawner, ICatcherSpawner catcherSpawner, SignalBus signalBus)
        {
            _playerSpawner = playerSpawner;
            _catcherSpawner = catcherSpawner;
            _signalBus = signalBus;
        }

        public void Load() 
        {
            _playerSpawner.Spawn();
            _catcherSpawner.Spawn();

            _signalBus.Fire(new OnLevelLoadedSignal());
        }

        public void Unload()
        {
            _playerSpawner.Unspawn();
            _catcherSpawner.Unspawn();
        }
    }
}