using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class EcsSpawnSystem : IEcsInitSystem
    {
        private EcsFilter _filter;
        private EcsPool<EcsSpawnComponent> _entityPool;
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<EcsSpawnComponent>().End();
            _entityPool = world.GetPool<EcsSpawnComponent>();

            foreach (int entity in _filter)
            {
                ref EcsSpawnComponent testComponent = ref _entityPool.Get(entity);

                ref var prefab = ref testComponent.Prefab;
                ref var amount = ref testComponent.Amount;
                for (int i = 0; i < amount; i++)
                {
                    GameObject prefabInstance = GameObject.Instantiate(prefab);
                    prefabInstance.transform.position = new Vector3(Random.Range(-100, 100), 0f, Random.Range(-100, 100));
                }
            }
        }
    }
}