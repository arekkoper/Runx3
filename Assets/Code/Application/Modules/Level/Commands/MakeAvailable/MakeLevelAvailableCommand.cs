
using Assets.Code.Application.Commons.Interfaces.Mediator;

namespace Assets.Code.Application.Modules.Level.Commands.MakeAvailable
{
    public class MakeLevelAvailableCommand : ICommand
    {
        public int Id { get; set; }
    }
}