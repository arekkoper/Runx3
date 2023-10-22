
using Code.Application.Commons.Interfaces.Mediator;

namespace Code.Application.Modules.Level.Commands.SetScore
{
    public class SetScoreCommand : ICommand
    {
        public int LevelID { get; set; }
        public int Score { get; set; }
    }
}