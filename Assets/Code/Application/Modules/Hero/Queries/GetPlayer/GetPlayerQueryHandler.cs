using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Services;
using Code.Domain.Entities;

namespace Code.Application.Modules.Hero.Queries.GetPlayer
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