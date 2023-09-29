using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Domain.Entities;

namespace Assets.Code.Application.Modules.Hero.Commands.CreatePlayer
{
    public class CreatePlayerCommandHandler : ICommandHandler<CreatePlayerCommand, Player>
    {
        private readonly IPlayerService _playerService;

        public CreatePlayerCommandHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public Player Handle(CreatePlayerCommand command)
        {
            return _playerService.Create();
        }
    }
}