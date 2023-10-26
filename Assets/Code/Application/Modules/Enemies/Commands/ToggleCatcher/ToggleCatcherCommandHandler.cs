using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Spawners;

namespace Code.Application.Modules.Enemies.Commands.ToggleCatcher
{
    public class ToggleCatcherCommandHandler : ICommandHandler<ToggleCatcherCommand>
    {
        private readonly ICatcherSpawner _catcherSpawner;

        public ToggleCatcherCommandHandler(ICatcherSpawner catcherSpawner)
        {
            _catcherSpawner = catcherSpawner;
        }
        
        public void Handle(ToggleCatcherCommand command)
        {
            if (!_catcherSpawner.HasPresenter()) return;
            
            var presenter = _catcherSpawner.GetPresenter();

            presenter.enabled = !presenter.enabled;
        }
    }
}