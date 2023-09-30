﻿using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game.GameStates;
using Assets.Code.Application.Signals;
using Assets.Code.Domain.Commons.Abstractions;
using Zenject;

namespace Assets.Code.Application.Modules.Game
{
    public class GameManager : IInitializable, ITickable
    {
        private readonly SignalBus _signalBus;
        private readonly IMediator _mediator;

        public GameState CurrentState { get; set; }
        public string UI_MAIN_MENU { get => "UI_MainMenu"; }
        public string UI_GAME { get => "UI_Game"; }
        public string LEVEL_001 { get => "Level_001"; }

        public SignalBus SignalBus => _signalBus;
        public IMediator Mediator => _mediator;

        public GameManager(SignalBus signalBus, IMediator mediator)
        {
            _signalBus = signalBus;
            _mediator = mediator;
        }

        public void Initialize()
        {
            ChangeState(new Level001());
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
            _signalBus.Fire(new GameStateChangedSignal());
        }


    }
}