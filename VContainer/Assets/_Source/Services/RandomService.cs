using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public static class RandomService<T> where T : MonoBehaviour
    {
        private static T _lastPrefab;

        public static T GetRandomElement(List<T> prefabs)
        {
            T newPrefab;
            do
                newPrefab = prefabs[Random.Range(0, prefabs.Count)];
            while (newPrefab == _lastPrefab);

            _lastPrefab = newPrefab;
            return _lastPrefab;
        }
    }
}