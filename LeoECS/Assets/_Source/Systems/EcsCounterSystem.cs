using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class EcsCounterSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<EcsCounterComponent> _entityPool;
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<EcsCounterComponent>().End();
            _entityPool = world.GetPool<EcsCounterComponent>();
        }

        public void Run (IEcsSystems systems) {
            foreach (int entity in _filter)
            {
                ref EcsCounterComponent testComponent = ref _entityPool.Get(entity);

                ref var counter = ref testComponent.Counter;
                counter++;
                Debug.Log(counter);
            }
        }
    }
}