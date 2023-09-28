using Unity.Entities;

public struct PrefabData : IComponentData
{
    public float Time;
    public float TimeLeft;
    public float TimeDelta;
    public int Number;
    public float Range;
}