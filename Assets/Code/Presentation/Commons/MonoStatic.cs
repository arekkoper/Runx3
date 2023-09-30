
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Commons
{
    public class MonoStatic : MonoBehaviour
    {
        [Inject] protected DiContainer Container;

        protected virtual void Awake()
        {
            Container = ProjectContext.Instance.Container;

            Container.Inject(this);
        }
    }
}