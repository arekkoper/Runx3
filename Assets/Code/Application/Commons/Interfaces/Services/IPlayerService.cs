using Assets.Code.Domain.Entities;

public interface IPlayerService
{
    Player Create();
    Player GetPlayer();
    int GetScore();
    void IncreaseScore();
    void ResetScore();
}
