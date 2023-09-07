using ScriptableObjects;
using Services;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Pool
{
    public class TilePool
    {
        private List<GameObject> _prefabs;
        private float _roadLength;
        private bool _autoExpand;
        private Vector3 _distance;

        private List<GameObject> _pool;

        [Inject]
        public TilePool(TilePoolSO tilePoolSo)
        {
            _prefabs = tilePoolSo.Prefabs;
            _roadLength = tilePoolSo.RoadLength;
            _autoExpand = tilePoolSo.AutoExpand;
            _distance = tilePoolSo.Distance;

            CreatePool(tilePoolSo.TileCount);
        }

        public GameObject GetFreeElement()
        {
            if (HasFreeElement(out GameObject element))
                return element;

            if (_autoExpand)
                return CreateObject(true);

            throw new Exception("No free elements");
        }

        private void CreatePool(int count)
        {
            _pool = new List<GameObject>();

            for (int i = 0; i < count; i++)
            {
                CreateObject(true);
            }
        }

        private GameObject CreateObject(bool isActiveByDefault = false)
        {
            GameObject createdObject = GameObject.Instantiate(RandomService.GetRandomElement(_prefabs), _distance, new Quaternion());
            createdObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);

            if (isActiveByDefault)
                _distance.x += _roadLength;

            return createdObject;
        }

        private bool HasFreeElement(out GameObject element)
        {
            List<GameObject> unActivePool = new List<GameObject>();

            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].gameObject.activeInHierarchy)
                    unActivePool.Add(_pool[i]);
            }

            if (unActivePool.Count != 0)
            {
                element = RandomService.GetRandomElement(unActivePool);
                element.transform.position = _distance;
                _distance.x += _roadLength;
                element.SetActive(true);
                return true;
            }

            element = null;
            return false;
        }
    }
}