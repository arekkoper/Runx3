
using UnityEngine;

namespace Code.Presentation.Presenters
{
    public class ProjectilePresenter : MonoBehaviour
    {
        public float Speed { get; set; }
        public float Range { get; set; }

        private Vector3 _initialPoint;

        private void Start()
        {
            _initialPoint = transform.position;
        }

        private void Update()
        {
            transform.Translate(0, 0, Speed * Time.deltaTime, Space.Self);

            if(Vector3.Distance(transform.position, _initialPoint) >= Range)
                Destroy(gameObject);
        }


    }
}