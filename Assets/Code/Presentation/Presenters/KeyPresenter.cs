using Code.Application.Commons.Interfaces.Presenters;
using Code.Presentation.Controllers;
using UnityEngine;

namespace Code.Presentation.Presenters
{
    public class KeyPresenter : MonoBehaviour
    {
        public bool IsPicked { get; set; }
        public KeyGroupPresenter GroupPresenter { get; set; }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IPickable>(out var pickable)) return;

            GroupPresenter.Pick(this);
        }


    }
}