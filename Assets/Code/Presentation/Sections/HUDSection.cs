using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game;
using Code.Application.Modules.Game.Commands.CalculateScore;
using Code.Application.Modules.Level.Queries.GetCurrentLevel;
using Code.Application.Modules.Level.Queries.GetTheBestScore;
using Code.Application.Signals;
using Code.Presentation.Commons;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Sections
{
    public class HUDSection : MonoStatic
    {
        [Header("References")] 
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TMP_Text _currentScore;
        [SerializeField] private TMP_Text _levelID;
        [SerializeField] private TMP_Text _theBestScore;

        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly IMediator _mediator;
        [Inject] private readonly GameManager _gameManager;

        private bool _refreshCurrentScore;
        private float _score;

        public float Score { get => _score; }
        
        private void Start()
        {
            Refresh();
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerWinSignal>(Refresh);
            _signalBus.Subscribe<OnPlayerWinSignal>(DeactiveCurrentScoreRefresh);
            _signalBus.Subscribe<OnLevelLoadedSignal>(Refresh);
            _signalBus.Subscribe<OnLevelLoadedSignal>(ActiveCurrentScoreRefresh);
            _signalBus.Subscribe<OnPlayerKilledSignal>(DeactiveCurrentScoreRefresh);
            _signalBus.Subscribe<OnInGameMenuOpenSignal>(InGameMenuOpen);
            _signalBus.Subscribe<OnInGameMenuCloseSignal>(InGameMenuClose);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerWinSignal>(Refresh);
            _signalBus.Unsubscribe<OnPlayerWinSignal>(DeactiveCurrentScoreRefresh);
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(Refresh);
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(ActiveCurrentScoreRefresh);
            _signalBus.Unsubscribe<OnPlayerKilledSignal>(DeactiveCurrentScoreRefresh);
            _signalBus.Unsubscribe<OnInGameMenuOpenSignal>(InGameMenuOpen);
            _signalBus.Unsubscribe<OnInGameMenuCloseSignal>(InGameMenuClose);
        }

        private void Update()
        {
            if(_refreshCurrentScore)
            {
                _score = _mediator.Send(new CalculateScoreCommand()
                {
                    StartTime = _gameManager.StartLevelTime,
                    EndTime = Time.time
                });
            }

            _currentScore.text = $"Score: {_score}";
        }

        private void DeactiveCurrentScoreRefresh()
        {
            _refreshCurrentScore = false;
        }

        private void ActiveCurrentScoreRefresh()
        {
            _gameManager.StartLevelTime = Time.time;
            _score = 0;
            _refreshCurrentScore = true;
        }

        private void Refresh()
        {
            _theBestScore.text = $"The best: {_mediator.Send(new GetTheBestScoreQuery() { LevelID = _mediator.Send(new GetCurrentLevelCommand()).Id })}";
            _levelID.text = $"Level: {_mediator.Send(new GetCurrentLevelCommand()).Id}";
        }

        private void InGameMenuClose()
        {
            Show();
        }

        private void InGameMenuOpen()
        {
            Hide();
        }
        
        public void Show()
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