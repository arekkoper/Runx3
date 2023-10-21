using Assets.Code.Application.Commons.Interfaces.Spawners;
using Assets.Code.Domain.Entities;
using Assets.Code.Presentation.Effects;
using Assets.Code.Presentation.Presenters;
using Assets.Code.Presentation.Spawners;
using UnityEngine;
using Zenject;

public class PresentationInstaller : MonoInstaller
{
    [Header("Presenters")]
    [SerializeField] private PlayerPresenter _playerPresenter;
    [SerializeField] private CatcherPresenter _catcherPresenter;

    [Header("Hubs")]
    [SerializeField] private Transform _entitiesHub;
    [SerializeField] private Transform _uiHub;

    public override void InstallBindings()
    {
        //Presenters
        Container.BindFactory<Player, PlayerPresenter, PlayerPresenter.Factory>().FromComponentInNewPrefab(_playerPresenter).UnderTransform(_entitiesHub);
        Container.BindFactory<CatcherPresenter, CatcherPresenter.Factory>().FromComponentInNewPrefab(_catcherPresenter);

        //Spawners
        Container.BindInterfacesAndSelfTo<PlayerSpawner>().AsSingle();
        Container.Bind<ICatcherSpawner>().To<CatcherSpawner>().AsSingle();



    }
}