using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Commons.Interfaces.Repositories;
using Code.Application.Commons.Interfaces.Services;
using Code.Application.Modules.Level.Commands.MakeAvailable;
using Code.Infrastructure.Repositories;
using Code.Infrastructure.Services;
using NUnit.Framework;
using Zenject;

namespace Code.Tests
{
    [TestFixture]
    public class MakeLevelAvailableTest : ZenjectUnitTestFixture
    {
        [SetUp]
        public void CommonInstall()
        {
            Container.Bind<IMediator>().To<Mediator>().AsSingle();
            Container.Bind<ILevelRepository>().To<LevelRepository>().AsSingle();
            Container.Bind<ILevelService>().To<LevelService>().AsSingle();
            Container.Inject(this);
        }

        [Inject] private readonly IMediator _mediator;
        [Inject] private readonly ILevelService _levelService;

        [Test]
        public void ChangeLevelAvailableFromFalseToTrue()
        {
            var level = _levelService.Create();

            _mediator.Send(new MakeLevelAvailableCommand() { Id = level.Id });

            Assert.That(level.IsAvailable);
        }
    }
}