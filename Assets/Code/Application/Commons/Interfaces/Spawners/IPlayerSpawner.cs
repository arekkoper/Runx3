using Code.Presentation.Presenters;
using UnityEngine;

namespace Code.Application.Commons.Interfaces.Spawners
{
    public interface IPlayerSpawner
    {
        PlayerPresenter GetPresenter();
        bool HasPresenter();
        void Spawn();
        void Unspawn();
        Vector3 GetPlayerPosition();
    }
}