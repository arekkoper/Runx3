using Code.Presentation.Sections;
using Zenject;

namespace Code.Presentation.Installers
{
    public class UIGameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<HUDSection>().FromComponentInHierarchy().AsSingle();
        }
    }
}