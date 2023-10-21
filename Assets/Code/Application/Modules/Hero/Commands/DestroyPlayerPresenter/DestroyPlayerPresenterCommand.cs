using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Presentation.Presenters;

namespace Assets.Code.Application.Modules.Hero.Commands.DestroyPlayerPresenter
{
    public class DestroyPlayerPresenterCommand : ICommand
    {
        public PlayerPresenter PlayerPresenter { get; set; }
    }
}