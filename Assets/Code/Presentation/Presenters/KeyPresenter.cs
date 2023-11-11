using System;
using System.Collections;
using Code.Application.Commons.Interfaces.Presenters;
using UnityEngine;

namespace Code.Presentation.Presenters
{
    public class KeyPresenter : MonoBehaviour
    {
        [Header("Parameters")] 
        [SerializeField] private bool hasLifetime;
        [SerializeField] [Tooltip("It works only when you select hasLifetime bool")] private float lifetime;
        
        public bool IsPicked { get; set; }
        public KeyGroupPresenter GroupPresenter { get; set; }

        private void Start()
        {
            if (hasLifetime)
            {
                StartCoroutine(DecreaseLifetime());
            }
        }

        private IEnumerator DecreaseLifetime()
        {
            while (lifetime > 0f)
            {
                lifetime -= Time.deltaTime;

                if (lifetime <= 0f)
                {
                    GroupPresenter.Hide(this);
                }

                yield return new WaitForEndOfFrame();
            }
            
            StopAllCoroutines();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IPickable>(out var pickable)) return;
            
            StopAllCoroutines();
            GroupPresenter.Pick(this);
        }


    }
}