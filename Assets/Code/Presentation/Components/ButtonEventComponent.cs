using System;
using Code.Application.Signals;
using Code.Presentation.Commons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Components
{
    public class ButtonEventComponent : MonoStatic
    {
        [Header("Parameters")]
        [SerializeField] private bool isHeavy;
        
        [Inject] private readonly SignalBus _signal;
        
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => _signal.Fire(new OnButtonClick() { IsHeavy = isHeavy }) );
        }
    }
}