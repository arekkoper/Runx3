using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Services;
using Code.Domain.Entities;

namespace Code.Application.Modules.Hero.Commands.CreatePlayer
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