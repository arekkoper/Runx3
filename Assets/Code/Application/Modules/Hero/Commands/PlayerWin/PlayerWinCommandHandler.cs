﻿using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Modules.Game.Commands.CalculateScore;
using Assets.Code.Application.Modules.Level.Commands.MakeAvailable;
using Assets.Code.Application.Modules.Level.Queries.GetCurrentLevel;
using Assets.Code.Application.Signals;
using UnityEngine;
using Zenject;

namespace Assets.Code.Application.Modules.Hero.Commands.PlayerWin
{
    public class PlayerWinCommandHandler : ICommandHandler<PlayerWinCommand>
    {
        private readonly GameManager _gameManager;
        private readonly SignalBus _signalBus;
        private readonly IPlayerService _playerService;
        private readonly IMediator _mediator;

        public PlayerWinCommandHandler(GameManager gameManager, SignalBus signalBus, IPlayerService playerService, IMediator mediator)
        {
            _gameManager = gameManager;
            _signalBus = signalBus;
            _playerService = playerService;
            _mediator = mediator;
        }

        public void Handle(PlayerWinCommand command)
        {
            _playerService.IncreaseScore(_mediator.Send(new CalculateScoreCommand()
            {
                StartTime = _gameManager.StartLevelTime,
                EndTime = Time.time
            }));

            _signalBus.Fire(new OnPlayerWinSignal()); //this is for UI

            _mediator.Send(new MakeLevelAvailableCommand() { Id = _mediator.Send(new GetCurrentLevelCommand()).Id });

       }
    }
}