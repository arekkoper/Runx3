
using Assets.Code.Application.Commons.Interfaces.Mediator;

namespace Assets.Code.Application.Modules.Level.Commands.InitLevels
{
    public class InitLevelsCommand : ICommand
    {
        public int LevelCap { get; set; }
    }
}