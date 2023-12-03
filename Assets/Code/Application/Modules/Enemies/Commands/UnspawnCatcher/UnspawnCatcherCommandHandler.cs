using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Spawners;

namespace Assets.Code.Application.Modules.Enemies.Commands.UnspawnCatcher
{
    public class UnspawnCatcherCommandHandler : ICommandHandler<UnspawnCatcherCommand>
    {
        private readonly ICatcherSpawner _spawner;

        public UnspawnCatcherCommandHandler(ICatcherSpawner spawner)
        {
            _spawner = spawner;
        }
        public void Handle(UnspawnCatcherCommand command)
        {
            _spawner.Unspawn();
        }
    }
}
