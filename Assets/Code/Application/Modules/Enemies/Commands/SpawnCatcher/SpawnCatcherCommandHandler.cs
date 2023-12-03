using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Spawners;

namespace Assets.Code.Application.Modules.Enemies.Commands.SpawnCatcher
{
    public class SpawnCatcherCommandHandler : ICommandHandler<SpawnCatcherCommand>
    {
        private readonly ICatcherSpawner _catcherSpawner;

        public SpawnCatcherCommandHandler(ICatcherSpawner catcherSpawner)
        {
            _catcherSpawner = catcherSpawner;
        }
        public void Handle(SpawnCatcherCommand command)
        {
            _catcherSpawner.Spawn();
        }
    }
}
