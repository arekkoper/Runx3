using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Domain.Entities;

namespace Assets.Code.Application.Modules.Hero.Commands.CreatePlayer
{
    public class InitPlayerCommandHandler : ICommandHandler<InitPlayerCommand, Player>
    {
        private readonly IPlayerService _playerService;

        public InitPlayerCommandHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public Player Handle(InitPlayerCommand command)
        {
            return _playerService.Create();
        }
    }
}