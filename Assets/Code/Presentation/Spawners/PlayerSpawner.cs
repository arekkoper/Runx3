
using Assets.Code.Presentation.Hubs;
using Assets.Code.Presentation.Presenters;
using Zenject;

namespace Assets.Code.Presentation.Spawners
{
    public class PlayerSpawner : IInitializable
    {
        [Inject] private readonly PlayerPresenter.Factory _factory;
        [Inject] private readonly EntitiesHub _hub;

        public void Initialize()
        {
            Spawn();
        }

        public void Spawn()
        {
            var player = _factory.Create();

            player.transform.SetParent(_hub.transform);
        }
    }
}