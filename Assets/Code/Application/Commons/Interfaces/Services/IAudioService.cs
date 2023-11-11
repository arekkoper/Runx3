using Code.Application.Commons.Enums;

namespace Code.Application.Commons.Interfaces.Services
{
    public interface IAudioService
    {
        void PlaySound(SoundType type);
    }
}