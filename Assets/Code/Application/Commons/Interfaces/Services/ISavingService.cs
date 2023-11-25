namespace Assets.Code.Application.Commons.Interfaces.Services
{
    public interface ISavingService
    {
        void Save();
        void Load();
        bool IsSaveFileExist();
    }
}
