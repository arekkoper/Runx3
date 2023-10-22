
namespace Code.Application.Commons.Interfaces.Mediator
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
