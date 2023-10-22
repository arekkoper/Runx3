using Code.Application.Commons.Interfaces.Mediator;

namespace Code.Application.Modules.Level.Commands.RunLevel
{
    public class RunLevelCommand : ICommand
    {
        public int LevelID { get; set; }
    }
}