
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Modules.Game.Commands.ChangeLevel;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Statics.Interactions
{
    public class RunTestSceneInteraction : MonoBehaviour
    {
        [Inject] private readonly IMediator _mediator;

        public void Interact()
        {
            _mediator.Send(new ChangeLevelCommand() { LevelID = 0 });
        }

    }
}