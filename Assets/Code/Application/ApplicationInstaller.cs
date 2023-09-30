using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Signals;
using UnityEngine;
using Zenject;

namespace Assets.Code.Application
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();

            //Signals
            Container.DeclareSignal<LevelFinishedSignal>().OptionalSubscriber();
            Container.DeclareSignal<GameStateChangedSignal>().OptionalSubscriber();
        }
    }
}

