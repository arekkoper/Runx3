using Code.Application.Commons.Interfaces.Mediator;

namespace Code.Application.Modules.Game.Commands.ChangeLevel
{
    public class ChangeLevelCommand : ICommand
    {
        public int LevelID { get; set; }
        public bool WasRestart { get; set; }
    }
}