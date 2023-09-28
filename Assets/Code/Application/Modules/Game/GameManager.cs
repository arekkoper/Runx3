using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game.GameStates;
using Assets.Code.Domain.Commons.Abstractions;
using Assets.Code.Presentation.Presenters;
using System;
using Zenject;

namespace Assets.Code.Application.Modules.Game
{
    public class GameManager : IInitializable, ITickable
    {
        private readonly SignalBus _signalBus;
        private readonly IMediator _mediator;
        private readonly ScenePresenter.Factory _factory;

        public event Action OnStateChange;

        public GameState CurrentState { get; set; }
        public string UI_MAIN_MENU { get => "UI_MainMenu"; }
        public string UI_GAME { get => "UI_Game"; }
        public string LEVEL_001 { get => "Level_001"; }

        public SignalBus SignalBus => _signalBus;
        public IMediator Mediator => _mediator;

        public GameManager(SignalBus signalBus, IMediator mediator, ScenePresenter.Factory factory)
        {
            _signalBus = signalBus;
            _mediator = mediator;
            _factory = factory;
        }

        public void Initialize()
        {
            _factory.Create(this);
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
            OnStateChange?.Invoke();
        }


    }
}