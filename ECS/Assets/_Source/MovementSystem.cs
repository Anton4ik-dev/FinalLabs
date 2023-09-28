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
            .ForEach((ref Translation translation, ref PrefabMovement prefabMovement) =>
            {
                float radius = Vector3.Distance(new Vector3(0, .5f, 0), translation.Value);
                float angle = Mathf.Atan2(translation.Value.z, translation.Value.x) + prefabMovement.Speed;
                translation.Value = new Vector3(radius * Mathf.Cos(angle), .5f, radius * Mathf.Sin(angle));

                if(translation.Value.z > prefabMovement.Range)
                {
                    translation.Value.z = 0;
                }
            }).Schedule(inputDeps);
        return jobHandle;
    }
}