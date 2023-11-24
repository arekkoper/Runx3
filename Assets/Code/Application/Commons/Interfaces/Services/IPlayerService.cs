using Code.Domain.Entities;

namespace Code.Application.Commons.Interfaces.Services
{
    public interface IPlayerService
    {
        Player Create();
        Player GetPlayer();
        void ResetScore();
    }
}
