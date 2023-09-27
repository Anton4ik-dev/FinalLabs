using System;
using UnityEngine;

namespace TileSystem
{
    public interface IPool
    {
        public MonoBehaviour GetFreeElement();
    }
}
