
using Assets.Code.Application.Commons.Interfaces.Mediator;

namespace Assets.Code.Application.Modules.Game.Commands.CalculateScore
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