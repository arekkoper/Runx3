using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game.Commands.ChangeLevel;
using Code.Application.Modules.Game.Commands.LoadLevel;
using Code.Application.Modules.Level.Queries.GetCurrentLevel;
using Code.Presentation.Commons;
using Zenject;

namespace Code.Presentation.Interactions
{
    public class RestartGameInteraction : MonoStatic
    {
        [Inject] private readonly IMediator _mediator;

        public void Interact()
        {
            var currentLevelId = _mediator.Send(new GetCurrentLevelCommand()).Id;

            _mediator.Send(new ChangeLevelCommand() { LevelID = currentLevelId, WasRestart = true });

            //_mediator.Send(new LoadLevelCommand() { WasRestart = true });
        }
    }
}