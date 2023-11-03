using System.Collections.Generic;
using System.Linq;
using Code.Application.Signals;
using Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Presenters
{
    public class KeyGroupPresenter : MonoStatic
    {
        [Header("Parameters")]
        [SerializeField] private string id;
        
        [Inject] private readonly SignalBus _signalBus;
        
        private List<KeyPresenter> _keyPresenters = new();
        
        private void Start()
        {
            CreateKeyPresenterLists();
        }

        private void CreateKeyPresenterLists()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var keyPresenter = transform.GetChild(i).GetComponent<KeyPresenter>();

                keyPresenter.GroupPresenter = this;
                
                _keyPresenters.Add(keyPresenter);
            }
        }
        
        public void Pick(KeyPresenter keyPresenter)
        {
            keyPresenter.IsPicked = true;
            keyPresenter.gameObject.SetActive(false);
            
            CheckKeys();
        }

        private void CheckKeys()
        {
            if (!_keyPresenters.All(keypresenter => keypresenter.IsPicked)) return;
            
            _signalBus.Fire(new OnTriggerActiveSignal() { Id = id });
        }
    }
}