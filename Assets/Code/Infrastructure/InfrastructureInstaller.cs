using Assets.Code.Application.Commons.Interfaces.Loaders;
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Commons.Interfaces.Repositories;
using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Infrastructure.Loaders;
using Assets.Code.Infrastructure.Repositories;
using Assets.Code.Infrastructure.Services;
using UnityEngine;
using Zenject;

public class InfrastructureInstaller : MonoInstaller
{
    [Header("Settings")]
    [SerializeField] private CatcherService.Settings CatcherSettings;

    public override void InstallBindings()
    {
        //Repositories
        Container.Bind<ILevelRepository>().To<LevelRepository>().AsSingle();
        Container.Bind<ICatcherRepository>().To<CatcherRepository>().AsSingle();

        ////Settings
        //Container.BindInstance(CatcherSettings);

        //Services
        SignalBusInstaller.Install(Container);
        Container.Bind<IMediator>().To<Mediator>().AsSingle();
        Container.Bind<IPlayerService>().To<PlayerService>().AsSingle();
        Container.Bind<ILevelService>().To<LevelService>().AsSingle();
        Container.Bind<ICatcherService>().To<CatcherService>().AsSingle().WithArguments(CatcherSettings);

        //Loaders
        Container.Bind<ILevelLoader>().To<LevelLoader>().AsSingle();

    }
}