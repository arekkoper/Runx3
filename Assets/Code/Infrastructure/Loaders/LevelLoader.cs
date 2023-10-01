using Assets.Code.Application.Commons.Interfaces.Loaders;
using Assets.Code.Presentation.Spawners;

namespace Assets.Code.Infrastructure.Loaders
{
    public class LevelLoader : ILevelLoader
    {
        private readonly PlayerSpawner _playerSpawner;
        private readonly CatcherSpawner _catcherSpawner;

        public LevelLoader(PlayerSpawner playerSpawner, CatcherSpawner catcherSpawner)
        {
            _playerSpawner = playerSpawner;
            _catcherSpawner = catcherSpawner;
        }

        public void Load() 
        {
            _playerSpawner.Spawn();
            _catcherSpawner.Spawn();
        }

        public void Unload()
        {
            _playerSpawner.Unspawn();
            _catcherSpawner.Unspawn();
        }
    }
}