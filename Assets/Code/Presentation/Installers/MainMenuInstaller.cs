using Code.Presentation.Controllers;
using Zenject;

namespace Code.Presentation.Installers
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