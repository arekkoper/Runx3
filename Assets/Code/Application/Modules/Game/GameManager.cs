using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game.GameStates;
using Assets.Code.Application.Modules.Hero.Commands.CreatePlayer;
using Assets.Code.Application.Modules.Level.Commands.InitLevels;
using Assets.Code.Application.Signals;
using Assets.Code.Domain.Commons.Abstractions;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Code.Application.Modules.Game
{
    public class GameManager : IInitializable, ITickable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IMediator _mediator;

        public GameState CurrentState { get; set; }
        public string UI_MAIN_MENU { get => "UI_MainMenu"; }
        public string UI_GAME { get => "UI_Game"; }
        public Dictionary<int, string> LEVELS { get; } = new()
        {
            {0, "Level_Test" },
            {1, "Level_001" },
            {2, "Level_002" },
            {3, "Level_003" }
        };
        public float StartLevelTime { get; set; }

        public SignalBus SignalBus => _signalBus;
        public IMediator Mediator => _mediator;

        public GameManager(SignalBus signalBus, IMediator mediator)
        {
            _signalBus = signalBus;
            _mediator = mediator;
        }

        public void Initialize()
        {
            //Initiator commands
            _mediator.Send(new InitPlayerCommand());
            _mediator.Send(new InitLevelsCommand() { LevelCap = 3 });

            _signalBus.Subscribe<OnScenesLoadedSignal>(EnterState);

            ChangeState(new MainMenuState());
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<OnScenesLoadedSignal>(EnterState);
        }

        public void Tick()
        {
            CurrentState.UpdateState();
        }

        public void ChangeState(GameState state)
        {
            state.Manager = this;
            CurrentState = state;
            CurrentState.ReloadScenes();
            _signalBus.Fire(new OnGameStateChangedSignal());
        }

        public void EnterState()
        {
            CurrentState.EnterState();
        }

    }
}