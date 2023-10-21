using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Modules.Game.Commands.CalculateScore;
using Assets.Code.Application.Modules.Level.Queries.GetCurrentLevel;
using Assets.Code.Application.Modules.Level.Queries.GetTheBestScore;
using Assets.Code.Application.Signals;
using Assets.Code.Presentation.Commons;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Statics.UI
{
    public class HUDSection : MonoStatic
    {
        [Header("References")]
        [SerializeField] private TMP_Text _currentScore;
        [SerializeField] private TMP_Text _levelID;
        [SerializeField] private TMP_Text _theBestScore;

        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly IMediator _mediator;
        [Inject] private readonly GameManager _gameManager;

        private bool _refreshCurrentScore;
        private int _score;

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
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerWinSignal>(Refresh);
            _signalBus.Unsubscribe<OnPlayerWinSignal>(DeactiveCurrentScoreRefresh);
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(Refresh);
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(ActiveCurrentScoreRefresh);
            _signalBus.Unsubscribe<OnPlayerKilledSignal>(DeactiveCurrentScoreRefresh);
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


    }
}