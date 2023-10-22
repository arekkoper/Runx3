using Code.Application.Signals;
using Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Sections
{
    public class LoseSection : MonoStatic
    {
        [Header("References")]
        [SerializeField] private CanvasGroup _canvasGroup;

        [Inject] private readonly SignalBus _signalBus;

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerKilledSignal>(Show);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerKilledSignal>(Show);
        }

        private void Show()
        {
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = 0;
        }
    }
}