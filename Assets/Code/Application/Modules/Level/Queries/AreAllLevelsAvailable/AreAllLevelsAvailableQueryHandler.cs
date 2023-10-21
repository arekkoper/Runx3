using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Commons.Interfaces.Services;
using System.Linq;

namespace Assets.Code.Application.Modules.Level.Queries.AreAllLevelsAvailable
{
    public class AreAllLevelsAvailableQueryHandler : IQueryHandler<AreAllLevelsAvailableQuery, bool>
    {
        private readonly ILevelService _levelService;

        public AreAllLevelsAvailableQueryHandler(ILevelService levelService)
        {
            _levelService = levelService;
        }

        public bool Handle(AreAllLevelsAvailableQuery query)
        {
            var levels = _levelService.GetLevels();

            return levels.All(level => level.IsAvailable);
        }
    }
}