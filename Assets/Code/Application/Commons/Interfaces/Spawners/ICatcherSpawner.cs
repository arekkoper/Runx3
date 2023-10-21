using Assets.Code.Presentation.Presenters;
using Assets.Code.Presentation.Spawners.Points;

namespace Assets.Code.Application.Commons.Interfaces.Spawners
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
