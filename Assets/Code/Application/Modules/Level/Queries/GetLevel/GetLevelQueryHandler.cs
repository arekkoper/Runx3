using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Services;

namespace Code.Application.Modules.Level.Queries.GetLevel
{
    public class GetLevelQueryHandler : IQueryHandler<GetLevelQuery, Domain.Entities.Level>
    {
        private readonly ILevelService _levelService;

        public GetLevelQueryHandler(ILevelService levelService)
        {
            _levelService = levelService;
        }

        public Domain.Entities.Level Handle(GetLevelQuery query)
        {
            return _levelService.GetLevelById(query.Id);
        }
    }
}