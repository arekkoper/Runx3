using Assets.Code.Presentation.Presenters;
using Assets.Code.Presentation.Spawners.Points;

namespace Assets.Code.Application.Commons.Interfaces.Spawners
{
    public interface ICatcherSpawner
    {
        CatcherPresenter GetPresenter(int id);
        bool HasPresenter(int id);
        void SetSpawnPoint(CatcherSpawnPoint spawnPoint);
        void Spawn();
        void Unspawn();
    }
}
