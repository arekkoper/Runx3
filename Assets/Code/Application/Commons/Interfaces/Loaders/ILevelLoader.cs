namespace Code.Application.Commons.Interfaces.Loaders
{
    public interface ILevelLoader
    {
        void Load(bool wasRestart);
        void Unload();
    }
}
