using System;
using System.Collections.Generic;
using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Application.Modules.Game.Commands.Load;
using Assets.Code.Application.Modules.Game.Queries.IsSaveFileExist;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game.GameStates;
using Code.Application.Modules.Hero.Commands.CreatePlayer;
using Code.Application.Modules.Level.Commands.InitLevels;
using Code.Application.Signals;
using Code.Domain.Entities;
using Zenject;

namespace Code.Application.Modules.Game
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
            {3, "Level_003" },
            {4, "Level_004" },
            {5, "Level_005" },
            {6, "Level_006" },
            {7, "Level_007" },
            {8, "Level_008" },
            {9, "Level_009" },
            {10, "Level_010" },
            {11, "Level_011" },
            {12, "Level_012" },
            {13, "Level_013" }
        };
        public float StartLevelTime { get; set; }

        public SignalBus SignalBus => _signalBus;
        public IMediator Mediator => _mediator;

        public GameManager(
            SignalBus signalBus,
            IMediator mediator
            )
        {
            _signalBus = signalBus;
            _mediator = mediator;
        }

        public void Initialize()
        {
            //Initiator commands
            _mediator.Send(new InitPlayerCommand());
            _mediator.Send(new InitLevelsCommand() { LevelCap = 8 });

            if(_mediator.Send(new IsSaveFileExistQuery()))
            {
                _mediator.Send(new LoadCommand());
            }

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