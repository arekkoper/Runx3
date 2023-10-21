
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Commons.Interfaces.Services;
using UnityEngine;

namespace Assets.Code.Application.Modules.Level.Commands.SetScore
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

            if(command.Score > level.TheBestScore)
            {
                level.TheBestScore = command.Score;

                Debug.Log($"Set the best score {command.Score} for level {level.Id}");
            }
        }
    }
}