using Assets.Code.Application.Modules.Game;
using UnityEngine;
using Zenject;

namespace Assets.Code.Application
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
        }
    }
}

