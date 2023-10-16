
using Assets.Code.Application.Commons.Interfaces.Mediator;

namespace Assets.Code.Application.Modules.Game.Queries.GetLevelName
{
    public class GetLevelNameQueryHandler : IQueryHandler<GetLevelNameQuery, string>
    {
        private readonly GameManager _gameManager;

        public GetLevelNameQueryHandler(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public string Handle(GetLevelNameQuery query)
        {
            return _gameManager.CurrentLevelID.ToString();
        }
    }
}