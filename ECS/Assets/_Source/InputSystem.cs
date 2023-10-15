using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class InputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        bool isSpace = Input.GetKeyDown(KeyCode.Space);
        bool isEsc = Input.GetKeyDown(KeyCode.Escape);

        JobHandle jobHandle = Entities
            .WithName("MovementSystem")
            .ForEach((ref PrefabWarrior prefabMovement, ref PrefabInput prefabInput) =>
            {
                if(isSpace)
                {
                    prefabMovement.Speed += prefabInput.ChangeSpeed;
                    prefabMovement.Health -= prefabInput.ChangeHealth;
                } else if(isEsc)
                {
                    prefabMovement.Speed -= prefabInput.ChangeSpeed;
                    prefabMovement.Health += prefabInput.ChangeHealth;
                }
            }).Schedule(inputDeps);
        return jobHandle;
    }
}