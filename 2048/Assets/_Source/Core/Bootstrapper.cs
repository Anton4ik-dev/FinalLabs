using CellSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform _container;

        private CellSpawner _cellSpawner;

        [Inject]
        public void Construct(CellSpawner cellSpawner)
        {
            _cellSpawner = cellSpawner;
        }

        private void Awake()
        {
            _cellSpawner.SpawnCell(_container);
        }
    }
}