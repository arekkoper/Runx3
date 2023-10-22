using Code.Application.Modules.Game;
using Code.Application.Observers;
using Code.Application.Signals;
using Zenject;

namespace Code.Application
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();

            //Signals
            Container.DeclareSignal<OnPlayerWinSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnGameStateChangedSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnPlayerKilledSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnScenesLoadedSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnLevelLoadedSignal>().OptionalSubscriber();

            //Observers
            Container.BindInterfacesAndSelfTo<OnPlayerKilledObserver>().AsSingle();
            Container.BindInterfacesAndSelfTo<OnPlayerWinObserver>().AsSingle();
        }
    }
}

