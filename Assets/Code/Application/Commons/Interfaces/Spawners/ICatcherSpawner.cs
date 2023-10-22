using Code.Presentation.Presenters;
using Code.Presentation.Spawners.Points;

namespace Code.Application.Commons.Interfaces.Spawners
{
    public interface ICatcherSpawner
    {
        CatcherPresenter GetPresenter();
        bool HasPresenter();
        void SetSpawnPoint(CatcherSpawnPoint spawnPoint);
        void Spawn();
        void Unspawn();
    }
}
