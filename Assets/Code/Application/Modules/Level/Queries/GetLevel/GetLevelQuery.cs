using Code.Application.Commons.Interfaces.Mediator;

namespace Code.Application.Modules.Level.Queries.GetLevel
{
    public class GetLevelQuery : IQuery<Domain.Entities.Level>
    {
        public int Id { get; set; }
    }
}