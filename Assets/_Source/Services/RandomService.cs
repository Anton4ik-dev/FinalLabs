using System.Collections.Generic;
using UnityEngine;

namespace Service
{
    public class RandomService
    {
        private GameObject _newPrefab;
        private GameObject _lastPrefab;

        public GameObject GetRandomElement(List<GameObject> prefabs)
        {
            do
                _newPrefab = prefabs[Random.Range(0, prefabs.Count)];
            while (_newPrefab == _lastPrefab);

            _lastPrefab = _newPrefab;
            return _lastPrefab;
        }
    }
}