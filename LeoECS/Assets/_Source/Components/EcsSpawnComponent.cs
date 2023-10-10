using System;
using UnityEngine;

namespace Client
{
    [Serializable]
    public struct EcsSpawnComponent
    {
        public GameObject Prefab;
        public int Amount;
    }
}