
using Assets.Code.Presentation.Hubs;
using Assets.Code.Presentation.Spawners;
using Zenject;

namespace Assets.Code.Presentation
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Hubs
            Container.Bind<EntitiesHub>().FromComponentInHierarchy().AsSingle();

            //Spawners
            Container.BindInterfacesAndSelfTo<PlayerSpawner>().AsSingle();

        }
    }
}