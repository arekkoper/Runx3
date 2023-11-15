using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Structs;
using Code.Application.Signals;
using Code.Presentation.Commons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;
using AudioType = Code.Application.Commons.Enums.AudioType;

namespace Code.Presentation.Components
{
    public class ButtonEventComponent : MonoStatic
    {
        [Header("Parameters")] 
        [SerializeField] private AudioType audioType;
        [SerializeField] private float volume;
        
        [Inject] private readonly SignalBus _signal;
        
        private void Start()
        {
            var settings = new AudioSettings()
            {
                AudioType = audioType,
                Volume = volume
            };
            
            GetComponent<Button>().onClick.AddListener(() => _signal.Fire(new OnAudioSignal(){ Settings = settings }) );
        }
    }
}