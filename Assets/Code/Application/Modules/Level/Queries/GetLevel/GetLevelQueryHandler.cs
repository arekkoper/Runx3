
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Domain.Entities;

namespace Assets.Code.Application.Modules.Level.Queries.GetLevel
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