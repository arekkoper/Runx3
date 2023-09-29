using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Domain.Entities;

namespace Assets.Code.Application.Modules.Hero.Queries.GetPlayer
{
    public class GetPlayerQueryHandler : IQueryHandler<GetPlayerQuery, Player>
    {
        private readonly IPlayerService _playerService;

        public GetPlayerQueryHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public Player Handle(GetPlayerQuery query)
        {
            return _playerService.GetPlayer();
        }
    }
}