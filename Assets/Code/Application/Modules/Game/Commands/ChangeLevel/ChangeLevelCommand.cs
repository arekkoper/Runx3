using Assets.Code.Application.Commons.Interfaces.Mediator;

namespace Assets.Code.Application.Modules.Game.Commands.ChangeLevel
{
    public class ChangeLevelCommand : ICommand
    {
        public int LevelID { get; set; }
    }
}