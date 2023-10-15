using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class MovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        JobHandle jobHandle = Entities
            .WithName("MovementSystem")
            .ForEach((ref Translation translation, ref PrefabWarrior prefabWarrior) =>
            {
                translation.Value = new Vector3(translation.Value.x + prefabWarrior.Speed, .5f, translation.Value.z);
                Debug.Log(prefabWarrior.Health);
            }).Schedule(inputDeps);
        return jobHandle;
    }
}