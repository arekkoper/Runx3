using System.Linq;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Services;

namespace Code.Application.Modules.Level.Queries.AreAllLevelsAvailable
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