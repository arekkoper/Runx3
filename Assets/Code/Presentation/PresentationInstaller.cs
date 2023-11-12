using Code.Application.Commons.Interfaces.Spawners;
using Code.Domain.Entities;
using Code.Presentation.Audios;
using Code.Presentation.Controllers;
using Code.Presentation.Presenters;
using Code.Presentation.Spawners;
using UnityEngine;
using Zenject;

namespace Code.Presentation
{
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
            Container.BindFactory<CatcherPresenter, CatcherPresenter.Factory>().FromComponentInNewPrefab(_catcherPresenter).UnderTransform(_entitiesHub);

            //Spawners
            Container.Bind<IPlayerSpawner>().To<PlayerSpawner>().AsSingle();
            Container.Bind<ICatcherSpawner>().To<CatcherSpawner>().AsSingle();
            
            //Controllers
            Container.BindInterfacesAndSelfTo<CursorController>().AsSingle();
            Container.BindInterfacesAndSelfTo<TimeController>().AsSingle();
            
            //Audios
            Container.BindInterfacesAndSelfTo<DashAudio>().AsSingle();
            Container.BindInterfacesAndSelfTo<ButtonClickAudio>().AsSingle();

        }
    }
}