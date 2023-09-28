
using Assets.Code.Domain.Commons.Abstractions;
using Assets.Code.Domain.Entities.GameStates;
using System;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public class GameManager : MonoBehaviour
    {
        public event Action OnStateChange;

        public GameState CurrentState { get; set; }
        public string UI_MAIN_MENU { get => "UI_MainMenu"; }
        public string UI_GAME { get => "UI_Game"; }
        public string LEVEL_001 {get => "Level_001"; }


        private void Start()
        {
            ChangeState(new Level001());
        }

        private void Update()
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