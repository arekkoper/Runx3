﻿using Assets.Code.Application.Modules.Game.Commands.LoadLevel;
using Assets.Code.Application.Modules.Hero.Commands.CreatePlayer;
using Assets.Code.Domain.Commons.Abstractions;
using UnityEngine;

namespace Assets.Code.Application.Modules.Game.GameStates
{
    public class LevelState : GameState
    {
        public int LevelID { get; set; }

        public override void ReloadScenes()
        {
            ScenesToLoad.Add(Manager.UI_GAME);
            ScenesToLoad.Add(Manager.LEVELS[LevelID]);
            ScenesToUnload.Add(Manager.UI_MAIN_MENU);

            foreach (var item in Manager.LEVELS)
            {
                ScenesToUnload.Add(Manager.LEVELS[item.Key]);
            }

            Debug.Log($"Reload scenes");
        }

        public override void UpdateState()
        {
        }

        public override void EnterState()
        {
            Manager.Mediator.Send(new LoadLevelCommand());
            Manager.StartLevelTime = Time.time;

            Debug.Log($"Enter state Level {LevelID}");
        }

    }
}