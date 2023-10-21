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
    public override void InstallBindings()
    {
        //Repositories
        Container.Bind<ILevelRepository>().To<LevelRepository>().AsSingle();

        //Services
        SignalBusInstaller.Install(Container);
        Container.Bind<IMediator>().To<Mediator>().AsSingle();
        Container.Bind<IPlayerService>().To<PlayerService>().AsSingle();
        Container.Bind<ILevelService>().To<LevelService>().AsSingle();

        //Loaders
        Container.Bind<ILevelLoader>().To<LevelLoader>().AsSingle();

    }
}