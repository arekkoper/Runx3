using System;
using Code.Application.Signals;
using Code.Presentation.Commons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using AudioType = Code.Application.Commons.Enums.AudioType;

namespace Code.Presentation.Components
{
    public class ButtonEventComponent : MonoStatic
    {
        [Header("Parameters")]
        [SerializeField] private AudioType audioType;
        
        [Inject] private readonly SignalBus _signal;
        
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => _signal.Fire(new OnButtonClick() { AudioType = audioType }) );
        }
    }
}