using Code.Application.Commons.Interfaces.Mediator;

namespace Code.Application.Modules.Level.Queries.GetTheBestScore
{
    public class GetTheBestScoreQuery : IQuery<float>
    {
        public int LevelID { get; set; }
    }
}