using System;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game.Commands.ChangeLevel;
using Code.Application.Modules.Game.Commands.LoadLevel;
using Code.Application.Modules.Level.Queries.GetCurrentLevel;
using Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Interactions
{
    public class ReplayLevelInteraction : MonoStatic
    {
        [Inject] private readonly IMediator _mediator;
        
        public void Interact()
        {
            RestartLevel();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartLevel();
            }
        }

        private void RestartLevel()
        {
            var currentLevelId = _mediator.Send(new GetCurrentLevelCommand()).Id;

            _mediator.Send(new ChangeLevelCommand() { LevelID = currentLevelId, WasRestart = true });
        }
    }
}