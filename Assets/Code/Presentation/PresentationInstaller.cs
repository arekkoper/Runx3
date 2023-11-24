using Assets.Code.Presentation.Audios;
using Assets.Code.Presentation.Controllers;
using Assets.Code.Presentation.Factories;
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

        [Header("Factories")]
        [SerializeField] private AudioSourceFactory _audioSourceFactory;
        [SerializeField] private AudioListenerFactory _audioListenerFactory;

        [Header("Hubs")]
        [SerializeField] private Transform _entitiesHub;
        [SerializeField] private Transform _uiHub;
        [SerializeField] private Transform _audioHub;

        public override void InstallBindings()
        {
            //Presenters
            Container.BindFactory<Player, PlayerPresenter, PlayerPresenter.Factory>().FromComponentInNewPrefab(_playerPresenter).UnderTransform(_entitiesHub);
            Container.BindFactory<CatcherPresenter, CatcherPresenter.Factory>().FromComponentInNewPrefab(_catcherPresenter).UnderTransform(_entitiesHub);
            Container.BindFactory<AudioSourceFactory, AudioSourceFactory.Factory>().FromComponentInNewPrefab(_audioSourceFactory).UnderTransform(_audioHub);
            Container.BindFactory<AudioListenerFactory, AudioListenerFactory.Factory>().FromComponentInNewPrefab(_audioListenerFactory).UnderTransform(_audioHub);

            //Spawners
            Container.Bind<IPlayerSpawner>().To<PlayerSpawner>().AsSingle();
            Container.Bind<ICatcherSpawner>().To<CatcherSpawner>().AsSingle();
            
            //Controllers
            Container.BindInterfacesAndSelfTo<CursorController>().AsSingle();
            Container.BindInterfacesAndSelfTo<TimeController>().AsSingle();
            Container.BindInterfacesAndSelfTo<AudioListenerController>().AsSingle();
            Container.BindInterfacesAndSelfTo<MusicController>().AsSingle();

            //Audios
            Container.BindInterfacesAndSelfTo<WinAudio>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoseAudio>().AsSingle();


        }
    }
}