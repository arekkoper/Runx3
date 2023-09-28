using Assets.Code.Presentation.Presenters;
using Assets.Code.Presentation.Spawners;
using UnityEngine;
using Zenject;

public class PresentationInstaller : MonoInstaller
{
    [Header("Presenters")]
    [SerializeField] private PlayerPresenter _playerPresenter;

    public override void InstallBindings()
    {
        //Presenters
        Container.BindFactory<PlayerPresenter, PlayerPresenter.Factory>().FromComponentInNewPrefab(_playerPresenter);

    }
}