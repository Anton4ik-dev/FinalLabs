using System;
using UnityEngine;

namespace Client {
    [Serializable]
    public struct EcsMoveComponent {
        public Transform Anchor;
        public float Speed;
        public float Amplitude;
        public float StartZ;
    }
}