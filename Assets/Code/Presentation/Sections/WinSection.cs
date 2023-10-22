using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.UI;
using Code.Application.Modules.Level.Queries.AreAllLevelsAvailable;
using Code.Application.Signals;
using Code.Presentation.Commons;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Sections
{
    public class WinSection : MonoStatic, IWinSection
    {
        [Header("References")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private TMP_Text _title;

        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly IMediator _mediator;

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerWinSignal>(Show);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerWinSignal>(Show);
        }

        public void Show()
        {
            if(_mediator.Send(new AreAllLevelsAvailableQuery()))
            {
                _title.text = "You win the game!";
                _restartButton.SetActive(false);
            }

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