
using Assets.Code.Presentation.Controllers;
using Zenject;

namespace Assets.Code.Presentation.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Controllers
            Container.Bind<MainMenuController>().FromComponentInHierarchy().AsSingle();
        }
    }
}