using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public static class RandomService
    {
        private static GameObject _lastPrefab;

        public static GameObject GetRandomElement(List<GameObject> prefabs)
        {
            GameObject newPrefab;
            do
                newPrefab = prefabs[Random.Range(0, prefabs.Count)];
            while (newPrefab == _lastPrefab);

            _lastPrefab = newPrefab;
            return _lastPrefab;
        }
    }
}