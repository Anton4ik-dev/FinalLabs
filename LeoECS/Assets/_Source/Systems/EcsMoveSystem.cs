using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class EcsMoveSystem : IEcsInitSystem, IEcsRunSystem 
    {
        private float direction = 1;

        private EcsFilter _filter;
        private EcsPool<EcsMoveComponent> _entityPool;

        public void Init (IEcsSystems systems) {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<EcsMoveComponent>().End();
            _entityPool = world.GetPool<EcsMoveComponent>();
            foreach (int entity in _filter)
            {
                ref EcsMoveComponent testComponent = ref _entityPool.Get(entity);

                ref var anchor = ref testComponent.Anchor;
                ref var startZ = ref testComponent.StartZ;

                startZ = anchor.position.z;
            }
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref EcsMoveComponent testComponent = ref _entityPool.Get(entity);

                ref var anchor = ref testComponent.Anchor;
                ref var speed = ref testComponent.Speed;
                ref var amplitude = ref testComponent.Amplitude;
                ref var startZ = ref testComponent.StartZ;
                
                anchor.position += new Vector3(speed * Time.deltaTime, 0, speed * direction * Time.deltaTime);

                if(startZ+amplitude <= anchor.position.z && direction > 0)
                {
                    direction = -1;
                    startZ = anchor.position.z;
                }
                else if (startZ - amplitude >= anchor.position.z && direction < 0)
                {
                    direction = 1;
                    startZ = anchor.position.z;
                }
            }
        }
    }
}