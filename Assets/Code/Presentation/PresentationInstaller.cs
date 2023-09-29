using Assets.Code.Application.Modules.Game;
using Assets.Code.Domain.Entities;
using Assets.Code.Presentation.Presenters;
using Assets.Code.Presentation.Spawners;
using UnityEngine;
using Zenject;

public class PresentationInstaller : MonoInstaller
{
    [Header("Presenters")]
    [SerializeField] private PlayerPresenter _playerPresenter;
    [SerializeField] private ScenePresenter _scenePresenter;

    [Header("Hubs")]
    [SerializeField] private Transform _entitiesHub;
    [SerializeField] private Transform _uiHub;

    public override void InstallBindings()
    {
        //Presenters
        Container.BindFactory<Player, PlayerPresenter, PlayerPresenter.Factory>().FromComponentInNewPrefab(_playerPresenter).UnderTransform(_entitiesHub);
        Container.BindFactory<GameManager, ScenePresenter, ScenePresenter.Factory>().FromComponentInNewPrefab(_scenePresenter).UnderTransform(_uiHub);

        //Spawners
        Container.BindInterfacesAndSelfTo<PlayerSpawner>().AsSingle();

    }
}