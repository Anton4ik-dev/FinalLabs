using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TilePoolSO", menuName = "SO/TilePool", order = 0)]
    public class TilePoolSO : ScriptableObject
    {
        [SerializeField] private List<GameObject> _prefabs;
        [SerializeField] private float _roadLength;
        [SerializeField] private int _tileCount;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private Vector3 _distance;

        public List<GameObject> Prefabs { get => _prefabs; private set { } }
        public float RoadLength { get => _roadLength; private set { } }
        public int TileCount { get => _tileCount; private set { } }
        public bool AutoExpand { get => _autoExpand; private set { } }
        public Vector3 Distance { get => _distance; private set { } }
    }
}