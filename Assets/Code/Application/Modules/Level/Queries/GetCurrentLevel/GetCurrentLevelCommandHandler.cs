
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Modules.Level.Queries.GetLevel;
using System.Linq;

namespace Assets.Code.Application.Modules.Level.Queries.GetCurrentLevel
{
    public class GetCurrentLevelCommandHandler : IQueryHandler<GetCurrentLevelCommand, Domain.Entities.Level>
    {
        private readonly ILevelService _levelService;

        public GetCurrentLevelCommandHandler(ILevelService levelService)
        {
            _levelService = levelService;
        }

        public Domain.Entities.Level Handle(GetCurrentLevelCommand query)
        {
            return _levelService.GetLevels().Where(level => level.IsRunning).FirstOrDefault();
        }
    }
}