using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Services;

namespace Code.Application.Modules.Level.Commands.SetScore
{
    public class SetScoreCommandHandler : ICommandHandler<SetScoreCommand>
    {
        private readonly ILevelService _levelService;

        public SetScoreCommandHandler(ILevelService levelService)
        {
            _levelService = levelService;
        }

        public void Handle(SetScoreCommand command)
        {
            var level = _levelService.GetLevelById(command.LevelID);

            if(command.Score < level.TheBestScore || level.TheBestScore == 0)
            {
                level.TheBestScore = command.Score;

            }
        }
    }
}