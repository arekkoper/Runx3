using Code.Application.Commons.Interfaces.Mediator;
using Code.Presentation.Presenters;

namespace Code.Application.Modules.Hero.Commands.DestroyPlayerPresenter
{
    public class DestroyPlayerPresenterCommand : ICommand
    {
        public PlayerPresenter PlayerPresenter { get; set; }
    }
}