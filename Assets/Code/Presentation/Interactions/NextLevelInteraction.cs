using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game.Commands.ChangeLevel;
using Code.Application.Modules.Level.Commands.MakeAvailable;
using Code.Application.Modules.Level.Queries.GetCurrentLevel;
using Code.Presentation.Commons;
using Zenject;

namespace Code.Presentation.Interactions
{
    public class NextLevelInteraction : MonoStatic
    {
        [Inject] private readonly IMediator _mediator;

        public void Interact()
        {
            var currentLevelId = _mediator.Send(new GetCurrentLevelCommand()).Id;
            var nextLevelId = currentLevelId + 1;

            _mediator.Send(new MakeLevelAvailableCommand() { Id = nextLevelId });
            _mediator.Send(new ChangeLevelCommand() { LevelID = nextLevelId });
        }
    }
}