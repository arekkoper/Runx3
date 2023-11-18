using Assets.Code.Presentation.Factories;
using Code.Application.Commons.Interfaces.Services;
using Code.Infrastructure.Services;
using Code.Presentation.Effects;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Installers
{
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
}