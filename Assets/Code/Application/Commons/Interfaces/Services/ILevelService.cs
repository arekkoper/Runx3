using System.Collections.Generic;
using Code.Domain.Entities;

namespace Code.Application.Commons.Interfaces.Services
{
    public interface ILevelService
    {
        List<Level> GetLevels();
        Level GetLevelById(int id);
        Level Create();
    }
}
