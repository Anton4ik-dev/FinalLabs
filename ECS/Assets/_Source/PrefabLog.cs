using Unity.Entities;

public struct PrefabLog : IComponentData
{
    public float Time;
    public float TimeLeft;
    public float TimeDelta;
    public int Number;
}