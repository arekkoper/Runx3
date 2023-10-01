using Assets.Code.Presentation.Presenters;
using UnityEngine;

namespace Assets.Code.Presentation.Spawners
{
    public class PlayerSpawner
    {
        private PlayerPresenter _presenter;

        private readonly PlayerPresenter.Factory _factory;
        private readonly IPlayerService _playerService;

        public PlayerSpawner(PlayerPresenter.Factory factory, IPlayerService playerService)
        {
            _factory = factory;
            _playerService = playerService;
        }

        public void Spawn()
        {
            Unspawn();

            _presenter = _factory.Create(_playerService.GetPlayer());
        }

        public void Unspawn()
        {
            if (_presenter != null)
            {
                Object.Destroy(_presenter.gameObject);
            }
        }

        public bool HasPresenter()
        {
            return _presenter != null;
        }

        public Vector3 GetPlayerPosition()
        {
            return _presenter.transform.position;
        }

    }
}