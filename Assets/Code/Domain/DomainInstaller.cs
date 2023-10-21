using Assets.Code.Domain.Entities;
using UnityEngine;
using Zenject;

namespace Assets.Code.Domain
{
    public class DomainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Entities
            Container.Bind<Catcher>().AsTransient();
        }
    }
}
