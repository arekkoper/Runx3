
using Code.Application.Commons.Interfaces.Mediator;

namespace Code.Application.Modules.Game.Commands.CalculateScore
{
    public class CalculateScoreCommand : ICommand<float>
    {
        public float StartTime { get; set; }
        public float EndTime { get; set; }
    }
}