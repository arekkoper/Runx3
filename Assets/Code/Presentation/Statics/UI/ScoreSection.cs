using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Hero.Queries.GetScore;
using Assets.Code.Application.Signals;
using Assets.Code.Presentation.Commons;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Statics.UI
{
    public class ScoreSection : MonoStatic
    {
        [Header("References")]
        [SerializeField] private TMP_Text _scoreText;

        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly IMediator _mediator;

        private void Start()
        {
            Refresh();
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<OnPlayerWinSignal>(Refresh);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<OnPlayerWinSignal>(Refresh);
        }

        private void Refresh()
        {
            _scoreText.text = $"Score: {_mediator.Send(new GetScoreQuery())}";
        }
    }
}