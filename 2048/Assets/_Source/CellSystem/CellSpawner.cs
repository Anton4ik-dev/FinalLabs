using UnityEngine;

namespace CellSystem
{
    public class CellSpawner
    {
        private CellView _cellPrefab;
        private CellGrid _cellGrid;

        public CellSpawner(CellGrid cellGrid)
        {
            _cellPrefab = Resources.Load<CellView>("Cell");
            _cellGrid = cellGrid;
        }

        public void SpawnCell(Transform container)
        {
            if (!_cellGrid.IsLost)
            {
                int x = -1;
                int y = -1;
                int value = 2;
                CellView cellView = GameObject.Instantiate(_cellPrefab, container);
                cellView.transform.position = new Vector2(x, -y);
                Cell cell = new Cell(x, y, value, cellView);

                while (_cellGrid.AddCell(cell))
                {
                    x = Random.Range(0, 4);
                    y = Random.Range(0, 4);
                    cellView.transform.position = new Vector2(x, -y);
                    cell = new Cell(x, y, value, cellView);
                }
            }
        }
    }
}