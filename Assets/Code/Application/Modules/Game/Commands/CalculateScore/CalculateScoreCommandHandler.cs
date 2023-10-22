
using Code.Application.Commons.Interfaces.Mediator;

namespace Code.Application.Modules.Game.Commands.CalculateScore
{
    public class CalculateScoreCommandHandler : ICommandHandler<CalculateScoreCommand, int>
    {
        public int Handle(CalculateScoreCommand command)
        {
            var score = (int)(command.EndTime - command.StartTime);

            return score;
        }
    }
}