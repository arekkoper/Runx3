using Assets.Code.Application.Observers;
using Assets.Code.Application.Signals;
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
            Container.DeclareSignal<OnInGameMenuCloseSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnInGameMenuOpenSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnReturnToMenuSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnPlayerDashSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnTriggerActiveSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnAudioSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnSpikeTrapStickingOutSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnTowerShootSignal>().OptionalSubscriber();
            Container.DeclareSignal<OnCatcherSpawnedSignal>().OptionalSubscriber();

            //Observers
            Container.BindInterfacesAndSelfTo<OnPlayerKilledObserver>().AsSingle();
            Container.BindInterfacesAndSelfTo<OnPlayerWinObserver>().AsSingle();
            Container.BindInterfacesAndSelfTo<OnCallCatcherObserver>().AsSingle();
        }
    }
}

