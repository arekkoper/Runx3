using Code.Application.Commons.Interfaces.Loaders;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Repositories;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Interfaces.Storages;
using Code.Infrastructure.Loaders;
using Code.Infrastructure.Repositories;
using Code.Infrastructure.Services;
using Code.Infrastructure.Storages;
using Zenject;

namespace Code.Infrastructure
{
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
            Container.Bind<IAudioService>().To<AudioService>().AsTransient();

            //Loaders
            Container.Bind<ILevelLoader>().To<LevelLoader>().AsSingle();

            //Storages
            Container.Bind<ISoundStorage>().To<SoundStorage>().FromScriptableObjectResource("Storages/SoundStorage")
                .AsSingle();
        }
    }
}