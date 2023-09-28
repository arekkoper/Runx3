
using Assets.Code.Presentation.Presenters;
using Zenject;

namespace Assets.Code.Presentation.Spawners
{
    public class PlayerSpawner
    {
        private readonly PlayerPresenter.Factory _factory;

        public PlayerSpawner(PlayerPresenter.Factory factory)
        {
            _factory = factory;
        }

        public void Spawn()
        {
            _factory.Create();

        }
    }
}