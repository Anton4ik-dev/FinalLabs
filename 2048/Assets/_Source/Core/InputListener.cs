using CellSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private Transform _container;

        private CellSpawner _cellSpawner;
        private CellGrid _cellGrid;

        [Inject]
        public void Construct(CellSpawner cellSpawner, CellGrid cellGrid)
        {
            _cellSpawner = cellSpawner;
            _cellGrid = cellGrid;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _cellGrid.MoveCells(MoveDirection.UP);
                SpawnCell();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _cellGrid.MoveCells(MoveDirection.RIGHT);
                SpawnCell();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _cellGrid.MoveCells(MoveDirection.DOWN);
                SpawnCell();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _cellGrid.MoveCells(MoveDirection.LEFT);
                SpawnCell();
            }
        }

        public void SpawnCell()
        {
            _cellSpawner.SpawnCell(_container);
        }
    }
}