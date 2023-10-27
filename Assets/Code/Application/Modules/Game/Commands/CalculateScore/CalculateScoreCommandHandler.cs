
using System;
using Code.Application.Commons.Interfaces.Mediator;

namespace Code.Application.Modules.Game.Commands.CalculateScore
{
    public class CalculateScoreCommandHandler : ICommandHandler<CalculateScoreCommand, float>
    {
        public float Handle(CalculateScoreCommand command)
        {
            var score = command.EndTime - command.StartTime;

            score = (float)Math.Round(score, 2);
            
            return score;
        }
    }
}