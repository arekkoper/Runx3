using Assets.Code.Application.Signals;
using Assets.Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Presenters
{
    public class ShooterPresenter : MonoStatic
    {
        [Header("References")]
        [SerializeField] private Transform _bulletPoint;
        [SerializeField] private ProjectilePresenter _projectilePresenter;

        [Header("Parameters")]
        [SerializeField] private float _fireRate;
        [SerializeField] private float _speed;
        [SerializeField] private float _range;

        private float _lastFireTime = 0f;

        public float Range { get => _range; }

        [Inject] private readonly SignalBus _signalBus;

        private void OnEnable()
        {
            _signalBus.Subscribe<OnLevelLoadedSignal>(Restart);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(Restart);
        }

        private void Update()
        {
            if(Time.time >= _lastFireTime + _fireRate)
            {
                _lastFireTime = Time.time;
                
                var projectile = Instantiate(_projectilePresenter, _bulletPoint.position, _bulletPoint.rotation, _bulletPoint);
                
                projectile.Speed = _speed;
                projectile.Range = _range;
            }
        }

        private void Restart()
        {
            _lastFireTime = 0f;
            for(int i = 0; i < _bulletPoint.childCount; i++)
            {
                Destroy(_bulletPoint.GetChild(i).gameObject);
            }
        }
    }
}