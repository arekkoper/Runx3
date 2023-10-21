using Assets.Code.Application.Commons.Interfaces.Mediator;

namespace Assets.Code.Application.Modules.Level.Commands.RunLevel
{
    public class RunLevelCommand : ICommand
    {
        public int LevelID { get; set; }
    }
}