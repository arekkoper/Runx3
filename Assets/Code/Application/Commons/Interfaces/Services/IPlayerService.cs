using Code.Domain.Entities;

namespace Code.Application.Commons.Interfaces.Services
{
    public interface IPlayerService
    {
        Player Create();
        Player GetPlayer();
        int GetScore();
        void IncreaseScore(int score);
        void ResetScore();
        void Save();
    }
}
