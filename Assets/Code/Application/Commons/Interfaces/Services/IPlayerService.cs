using Assets.Code.Domain.Entities;

public interface IPlayerService
{
    Player Create();
    Player GetPlayer();
    int GetScore();
    void IncreaseScore(int score);
    void ResetScore();
    void Save();
}
