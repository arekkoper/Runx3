using Assets.Code.Application.Commons.Interfaces.Services;
using Assets.Code.Infrastructure.Providers;
using Assets.Code.Presentation.Effects;
using UnityEngine;
using Zenject;

public class CoreSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Providers
        Container.Bind<IPostProcessService>().To<PostProcessService>().FromComponentInHierarchy().AsSingle();

        //Effects
        Container.BindInterfacesAndSelfTo<CatcherVignetteEffect>().AsSingle();

    }
}