using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game.Commands.ChangeLevel;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Interactions
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