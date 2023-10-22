
namespace Code.Application.Commons.Interfaces.Mediator
{
    public interface IMediator
    {
        TResult Send<TResult>(IQuery<TResult> query);
        void Send(ICommand command);

        TReturn Send<TReturn>(ICommand<TReturn> command);
    }
}
