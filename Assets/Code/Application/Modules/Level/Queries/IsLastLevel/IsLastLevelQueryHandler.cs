using System.Linq;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Modules.Level.Queries.GetCurrentLevel;

namespace Code.Application.Modules.Level.Queries.IsLastLevel
{
    public class IsLastLevelQueryHandler : IQueryHandler<IsLastLevelQuery, bool>
    {
        private readonly ILevelService _levelService;
        private readonly IMediator _mediator;

        public IsLastLevelQueryHandler(ILevelService levelService, IMediator mediator)
        {
            _levelService = levelService;
            _mediator = mediator;
        }
        
        public bool Handle(IsLastLevelQuery query)
        {
            var currentLevel = _mediator.Send(new GetCurrentLevelCommand());
            var lastLevel = _levelService.GetLevels().Last();

            return currentLevel.Id == lastLevel.Id;
        }
    }
}