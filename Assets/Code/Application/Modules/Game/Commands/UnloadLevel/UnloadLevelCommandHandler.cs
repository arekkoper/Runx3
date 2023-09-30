
using Assets.Code.Application.Commons.Interfaces.Loaders;
using Assets.Code.Application.Commons.Interfaces.Mediator;

namespace Assets.Code.Application.Modules.Game.Commands.UnloadLevel
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