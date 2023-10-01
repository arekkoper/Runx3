
using Assets.Code.Presentation.Commons;
using Zenject;

namespace Assets.Code.Presentation.Spawners.Points
{
    public class CatcherSpawnPoint : MonoStatic
    {
        [Inject] private readonly CatcherSpawner _spawner;

        private void Start()
        {
            _spawner.SetSpawnPoint(this);
        }
    }
}