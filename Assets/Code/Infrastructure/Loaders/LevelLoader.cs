using Assets.Code.Application.Commons.Interfaces.Loaders;
using Assets.Code.Presentation.Spawners;

namespace Assets.Code.Infrastructure.Loaders
{
    public class LevelLoader : ILevelLoader
    {
        private readonly PlayerSpawner _playerSpawner;

        public LevelLoader(PlayerSpawner playerSpawner)
        {
            _playerSpawner = playerSpawner;
        }

        public void Load() 
        {
            _playerSpawner.Spawn();
        }
    }
}