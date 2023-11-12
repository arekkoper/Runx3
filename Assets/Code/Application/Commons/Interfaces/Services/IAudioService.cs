using Code.Application.Commons.Structs;

namespace Code.Application.Commons.Interfaces.Services
{
    public interface IAudioService
    {
        void PlaySound(AudioSettings settings);
    }
}