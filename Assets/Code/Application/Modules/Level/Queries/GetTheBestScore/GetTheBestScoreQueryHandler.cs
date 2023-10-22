using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Services;

namespace Code.Application.Modules.Level.Queries.GetTheBestScore
{
    public class GetTheBestScoreQueryHandler : IQueryHandler<GetTheBestScoreQuery, int>
    {
        private readonly ILevelService _levelService;

        public GetTheBestScoreQueryHandler(ILevelService levelService)
        {
            _levelService = levelService;
        }

        public int Handle(GetTheBestScoreQuery query)
        {
            return _levelService.GetLevelById(query.LevelID).TheBestScore;
        }
    }
}