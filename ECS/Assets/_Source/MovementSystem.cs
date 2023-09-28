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
            .ForEach((ref Translation translation, ref PrefabData prefabData) =>
            {
                float radius = Vector3.Distance(new Vector3(0, .5f, 0), new Vector3(translation.Value.x, translation.Value.y, translation.Value.z));
                float angle = Mathf.Atan2(translation.Value.z, translation.Value.x) + .001f;
                translation.Value.x = radius * Mathf.Cos(angle);
                translation.Value.y = .5f;
                translation.Value.z = radius * Mathf.Sin(angle);
                if(translation.Value.z > prefabData.Range)
                {
                    translation.Value.z = 0;
                }
            }).Schedule(inputDeps);
        return jobHandle;
    }
}