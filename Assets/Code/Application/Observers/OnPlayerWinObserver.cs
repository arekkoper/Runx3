using System;
using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Application.Modules.Game.Commands.Save;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game;
using Code.Application.Modules.Game.Commands.CalculateScore;
using Code.Application.Modules.Level.Commands.MakeAvailable;
using Code.Application.Modules.Level.Commands.SetScore;
using Code.Application.Modules.Level.Queries.GetCurrentLevel;
using Code.Application.Signals;
using UnityEngine;
using Zenject;

namespace Code.Application.Observers
{
    public class OnPlayerWinObserver : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IMediator _mediator;
        private readonly GameManager _gameManager;

        public OnPlayerWinObserver(
            SignalBus signalBus,
            IMediator mediator,
            GameManager gameManager
            )
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
            var currentLevel = _mediator.Send(new GetCurrentLevelCommand());
            
            _mediator.Send(new SetScoreCommand()
            {
                LevelID = currentLevel.Id,
                Score = _mediator.Send(new CalculateScoreCommand()
                {
                    StartTime = _gameManager.StartLevelTime,
                    EndTime = Time.time
                })
            });

            var nextLevelId = currentLevel.Id + 1;
            
            _mediator.Send(new MakeLevelAvailableCommand() { Id = nextLevelId });

            _mediator.Send(new SaveCommand());
        }


    }
}