using System;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct LogJob : IJob
{
    public NativeArray<int> Numbers;

    public void Execute()
    {
        for (int i = 0; i < Numbers.Length; i++)
        {
            Debug.Log(Math.Log(Numbers[i]));
        }
    }
}