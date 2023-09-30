using UnityEngine;

namespace Assets.Code.Presentation.Presenters
{
    public class ShooterPresenter : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _bulletPoint;
        [SerializeField] private ProjectilePresenter _projectilePresenter;

        [Header("Parameters")]
        [SerializeField] private float _fireRate;
        [SerializeField] private float _speed;
        [SerializeField] private float _range;

        private float _lastFireTime = 0f;

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
    }
}