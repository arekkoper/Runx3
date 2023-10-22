using Code.Application.Commons.Interfaces.Presenters;
using UnityEngine;

namespace Code.Presentation.Components
{
    public class DieableComponent : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IDieable>(out var dieable)) return;

            dieable.Die();
        }
    }
}