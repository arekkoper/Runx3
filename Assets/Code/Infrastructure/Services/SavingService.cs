using Assets.Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Interfaces.Repositories;
using Code.Infrastructure.Repositories;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Code.Infrastructure.Services
{
    public class SavingService : ISavingService
    {
        private const string SAVEFILE = "levelRepoSave";
        private readonly ILevelRepository _levelRepository;

        public SavingService(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public void Save()
        {
            using(FileStream stream = new FileStream(GetPathToSaveFile(SAVEFILE), FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, _levelRepository.CaptureState());
            }
        }
        public void Load()
        {
            if(File.Exists(GetPathToSaveFile(SAVEFILE)))
            {
                using(FileStream stream = new FileStream(GetPathToSaveFile(SAVEFILE), FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    var data = (LevelRepository.Data)formatter.Deserialize(stream);

                    _levelRepository.RestoreState(data);
                }
            }
        }

        public bool IsSaveFileExist()
        {
            return File.Exists(GetPathToSaveFile(SAVEFILE));
        }

        private string GetPathToSaveFile(string fileName)
        {
            return Path.Combine(UnityEngine.Application.persistentDataPath, fileName + ".sav");
        }

        
    }
}
