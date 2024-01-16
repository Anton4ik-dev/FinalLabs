using CellSystem;
using Zenject;

namespace Core
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CellGrid>()
                .AsSingle()
                .NonLazy();

            Container.Bind<CellSpawner>()
                .AsSingle()
                .NonLazy();
        }
    }
}