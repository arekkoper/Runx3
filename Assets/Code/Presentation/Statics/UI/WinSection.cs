using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Signals;
using Assets.Code.Presentation.Commons;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Statics.UI
{
    public class WinSection : MonoStatic
    {
        [Header("References")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private TMP_Text _title;

        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly GameManager _gameManager;

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerWinSignal>(Show);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerWinSignal>(Show);
        }

        private void Show()
        {
            if(_gameManager.MaxLevelReached)
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