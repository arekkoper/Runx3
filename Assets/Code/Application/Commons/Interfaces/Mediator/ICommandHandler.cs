
namespace Code.Application.Commons.Interfaces.Mediator
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

    public interface ICommandHandler<TCommand, TReturn> where TCommand : ICommand<TReturn>
    {
        TReturn Handle(TCommand command);
    }
}
