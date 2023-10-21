using Assets.Code.Application.Commons.Interfaces.Mediator;

namespace Assets.Code.Application.Modules.Level.Queries.GetTheBestScore
{
    public class GetTheBestScoreQuery : IQuery<int>
    {
        public int LevelID { get; set; }
    }
}