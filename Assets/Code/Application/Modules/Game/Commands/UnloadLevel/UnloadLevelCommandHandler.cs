using Code.Application.Commons.Interfaces.Loaders;
using Code.Application.Commons.Interfaces.Mediator;

namespace Code.Application.Modules.Game.Commands.UnloadLevel
{
    public class UnloadLevelCommandHandler : ICommandHandler<UnloadLevelCommand>
    {
        private readonly ILevelLoader _levelLoader;

        public UnloadLevelCommandHandler(ILevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }

        public void Handle(UnloadLevelCommand command)
        {
            _levelLoader.Unload();
        }
    }
}