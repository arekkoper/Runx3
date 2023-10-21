using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Modules.Game.Commands.CalculateScore;
using Assets.Code.Application.Modules.Level.Commands.SetScore;
using Assets.Code.Application.Modules.Level.Queries.GetCurrentLevel;
using Assets.Code.Application.Signals;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Code.Application.Observers
{
    public class OnPlayerWinObserver : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IMediator _mediator;
        private readonly GameManager _gameManager;

        public OnPlayerWinObserver(SignalBus signalBus, IMediator mediator, GameManager gameManager)
        {
            _signalBus = signalBus;
            _mediator = mediator;
            _gameManager = gameManager;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<OnPlayerWinSignal>(Perform);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<OnPlayerWinSignal>(Perform);
        }

        private void Perform(OnPlayerWinSignal param)
        {
            _mediator.Send(new SetScoreCommand()
            {
                LevelID = _mediator.Send(new GetCurrentLevelCommand()).Id,
                Score = _mediator.Send(new CalculateScoreCommand()
                {
                    StartTime = _gameManager.StartLevelTime,
                    EndTime = Time.time
                })
            });
        }


    }
}