using Code.Application.Commons.Interfaces.Loaders;
using Code.Application.Commons.Interfaces.Mediator;

namespace Code.Application.Modules.Game.Commands.LoadLevel
{
    public class LoadLevelCommandHandler : ICommandHandler<LoadLevelCommand>
    {
        private readonly ILevelLoader _levelLoader;

        public LoadLevelCommandHandler(ILevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }

        public void Handle(LoadLevelCommand command)
        {
            _levelLoader.Load();
        }
    }
}