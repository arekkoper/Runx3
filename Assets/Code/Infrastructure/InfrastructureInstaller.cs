using Assets.Code.Application.Commons.Interfaces.Loaders;
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Infrastructure.Loaders;
using Assets.Code.Infrastructure.Services;
using Zenject;

public class InfrastructureInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Services
        SignalBusInstaller.Install(Container);
        Container.Bind<IMediator>().To<Mediator>().AsSingle();
        Container.Bind<IPlayerService>().To<PlayerService>().AsSingle();

        //Loaders
        Container.Bind<ILevelLoader>().To<LevelLoader>().AsSingle();
    }
}