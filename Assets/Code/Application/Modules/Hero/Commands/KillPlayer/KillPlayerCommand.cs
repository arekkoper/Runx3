using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Presentation.Presenters;

namespace Assets.Code.Application.Modules.Hero.Commands.KillPlayer
{
    public class KillPlayerCommand : ICommand
    {
        public PlayerPresenter PlayerPresenter { get; set; }
    }
}