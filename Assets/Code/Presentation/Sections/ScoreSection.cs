using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Hero.Queries.GetScore;
using Assets.Code.Application.Modules.Level.Queries.GetCurrentLevel;
using Assets.Code.Application.Signals;
using Assets.Code.Presentation.Commons;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Statics.UI
{
    public class ScoreSection : MonoStatic
    {
        [Header("References")]
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _levelText;

        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly IMediator _mediator;

        private void Start()
        {
            Refresh();
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerWinSignal>(Refresh);
            _signalBus.Subscribe<OnLevelLoadedSignal>(Refresh);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerWinSignal>(Refresh);
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(Refresh);
        }

        private void Refresh()
        {
            _scoreText.text = $"Score: {_mediator.Send(new GetScoreQuery())}";
            _levelText.text = $"Level: {_mediator.Send(new GetCurrentLevelCommand()).Id}";
        }
    }
}