using System.Linq;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Services;

namespace Code.Application.Modules.Level.Queries.GetCurrentLevel
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