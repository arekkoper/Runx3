
using Assets.Code.Application.Commons.Interfaces.Mediator;

namespace Assets.Code.Application.Modules.Game.Commands.ChangeGameState
{
    public class ChangeGameStateCommand : ICommand
    {
        public int LevelID { get; set; }
    }
}