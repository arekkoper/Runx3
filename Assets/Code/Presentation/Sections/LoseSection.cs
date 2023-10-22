using Code.Application.Signals;
using Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Sections
{
    public class LoseSection : MonoStatic
    {
        [Header("References")]
        [SerializeField] private CanvasGroup canvasGroup;

        [Inject] private readonly SignalBus _signalBus;

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerKilledSignal>(Show);
            _signalBus.Subscribe<OnLevelLoadedSignal>(Hide);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerKilledSignal>(Show);
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(Hide);
        }

        private void Show()
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0;
        }
    }
}