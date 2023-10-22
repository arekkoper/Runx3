using Code.Application.Commons.Interfaces.Spawners;
using Code.Presentation.Commons;
using Zenject;

namespace Code.Presentation.Spawners.Points
{
    public class CatcherSpawnPoint : MonoStatic
    {
        [Inject] private readonly ICatcherSpawner _spawner;

        private void Start()
        {
            _spawner.SetSpawnPoint(this);
        }
    }
}