
using Assets.Code.Application.Commons.Interfaces.Mediator;

namespace Assets.Code.Application.Modules.Hero.Queries.GetScore
{
    public class GetScoreQueryHandler : IQueryHandler<GetScoreQuery, int>
    {
        private readonly IPlayerService _playerService;

        public GetScoreQueryHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public int Handle(GetScoreQuery query)
        {
            return _playerService.GetScore();
        }
    }
}