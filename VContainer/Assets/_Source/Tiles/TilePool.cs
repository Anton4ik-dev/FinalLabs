using ScriptableObjects;
using Services;
using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace TileSystem
{
    public class TilePool<T> : IPool where T : MonoBehaviour
    {
        private List<T> _prefabs = new List<T>();
        private float _roadLength;
        private bool _autoExpand;
        private Vector3 _distance;

        private List<T> _pool;

        [Inject]
        public TilePool(TilePoolSO tilePoolSo)
        {
            for (int i = 0; i < tilePoolSo.Prefabs.Count; i++)
            {
                _prefabs.Add((T)tilePoolSo.Prefabs[i]);
            }
            _roadLength = tilePoolSo.RoadLength;
            _autoExpand = tilePoolSo.AutoExpand;
            _distance = tilePoolSo.Distance;

            CreatePool(tilePoolSo.TileCount);
        }

        public MonoBehaviour GetFreeElement()
        {
            if (HasFreeElement(out T element))
                return element;

            if (_autoExpand)
                return CreateObject(true);

            throw new Exception("No free elements");
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject(true);
            }
        }

        private MonoBehaviour CreateObject(bool isActiveByDefault = false)
        {
            T createdObject = GameObject.Instantiate(RandomService<T>.GetRandomElement(_prefabs), _distance, new Quaternion());
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);

            if (isActiveByDefault)
                _distance.x += _roadLength;

            return createdObject;
        }

        private bool HasFreeElement(out T element)
        {
            List<T> unActivePool = new List<T>();

            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].gameObject.activeInHierarchy)
                    unActivePool.Add(_pool[i]);
            }

            if (unActivePool.Count != 0)
            {
                element = RandomService<T>.GetRandomElement(unActivePool);
                element.transform.position = _distance;
                _distance.x += _roadLength;
                element.gameObject.SetActive(true);
                return true;
            }

            element = null;
            return false;
        }
    }
}