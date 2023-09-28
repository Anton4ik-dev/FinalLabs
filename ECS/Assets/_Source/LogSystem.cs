using System;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class LogSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        JobHandle jobHandle = Entities
            .WithName("LogSystem")
            .ForEach((ref PrefabData prefabData) =>
            {
                if(prefabData.TimeLeft <= 0)
                {
                    Debug.Log($"{Math.Log(prefabData.Number)}");
                    prefabData.TimeLeft = prefabData.Time;
                }
                prefabData.TimeLeft -= prefabData.TimeDelta;
            }).Schedule(inputDeps);
        return jobHandle;
    }
}