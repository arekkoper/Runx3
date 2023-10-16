using Assets.Code.Domain.Entities;
using System.Collections.Generic;

namespace Assets.Code.Application.Commons.Interfaces.Services
{
    public interface ILevelService
    {
        List<Level> GetLevels();
        Level GetLevelById(int id);
        Level Create();
    }
}
