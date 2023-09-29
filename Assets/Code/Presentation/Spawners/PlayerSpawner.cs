
using Assets.Code.Presentation.Presenters;
using Zenject;

namespace Assets.Code.Presentation.Spawners
{
    public class PlayerSpawner
    {
        private readonly PlayerPresenter.Factory _factory;
        private readonly IPlayerService _playerService;

        public PlayerSpawner(PlayerPresenter.Factory factory, IPlayerService playerService)
        {
            _factory = factory;
            _playerService = playerService;
        }

        public void Spawn()
        {
            _factory.Create(_playerService.GetPlayer());
        }
    }
}