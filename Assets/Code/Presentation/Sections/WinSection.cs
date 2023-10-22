using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.UI;
using Code.Application.Modules.Level.Queries.IsLastLevel;
using Code.Application.Signals;
using Code.Presentation.Commons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Sections
{
    public class WinSection : MonoStatic, IWinSection
    {
        [Header("References")]
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Button nextLevelButton;

        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly IMediator _mediator;

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerWinSignal>(Show);
            _signalBus.Subscribe<OnLevelLoadedSignal>(Hide);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerWinSignal>(Show);
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(Hide);
        }

        public void Show()
        {
            if(_mediator.Send(new IsLastLevelQuery()))
            {
                nextLevelButton.gameObject.SetActive(false);
            }

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