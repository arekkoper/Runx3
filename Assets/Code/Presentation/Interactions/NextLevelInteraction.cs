
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Modules.Game.Commands.ChangeLevel;
using Assets.Code.Application.Modules.Level.Commands.MakeAvailable;
using Assets.Code.Application.Modules.Level.Queries.GetCurrentLevel;
using Assets.Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Statics.Interactions
{
    public class NextLevelInteraction : MonoStatic
    {
        [Inject] private readonly IMediator _mediator;

        public void Interact()
        {
            var currentLevelId = _mediator.Send(new GetCurrentLevelCommand()).Id;
            var nextLevelId = currentLevelId + 1;

            Debug.Log($"Current level: {currentLevelId}, Next level: {nextLevelId}");

            _mediator.Send(new MakeLevelAvailableCommand() { Id = nextLevelId });
            _mediator.Send(new ChangeLevelCommand() { LevelID = nextLevelId });
        }
    }
}