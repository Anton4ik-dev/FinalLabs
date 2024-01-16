namespace CellSystem
{
    public class CellGrid
    {
        public bool IsLost { get => _cellCount == _cellGrid.Length; private set { } }

        private const int CELL_LENGTH = 4;

        private Cell[,] _cellGrid = new Cell[CELL_LENGTH, CELL_LENGTH];

        private int _cellCount = 0;

        private void MoveCell(int addX, int addY, int x, int y)
        {
            Cell chosenCell = _cellGrid[x, y];

            if (chosenCell is not null)
            {
                bool isToCheck = true;

                while (_cellGrid[chosenCell.X + addX, chosenCell.Y + addY] == null)
                {
                    _cellGrid[chosenCell.X, chosenCell.Y] = null;
                    chosenCell.SetCoordinates(chosenCell.X + addX, chosenCell.Y + addY);
                    _cellGrid[chosenCell.X, chosenCell.Y] = chosenCell;

                    if ((addX == 1 && chosenCell.X == 3)
                        || (addX == -1 && chosenCell.X == 0)
                        || (addY == 1 && chosenCell.Y == 3)
                        || (addY == -1 && chosenCell.Y == 0))
                    {
                        isToCheck = false;
                        break;
                    }
                }

                _cellGrid[chosenCell.X, chosenCell.Y].Move();

                if (isToCheck)
                {
                    if (_cellGrid[chosenCell.X + addX, chosenCell.Y + addY].Value == chosenCell.Value)
                    {
                        _cellGrid[chosenCell.X, chosenCell.Y].Destroy();
                        _cellGrid[chosenCell.X, chosenCell.Y] = null;
                        _cellCount--;
                        _cellGrid[chosenCell.X + addX, chosenCell.Y + addY].IncreaseValue();
                    }
                }
            }
        }

        public bool AddCell(Cell cell)
        {
            if (cell.X >= 0 && cell.Y >= 0 && _cellCount != _cellGrid.Length)
            {
                if (_cellGrid[cell.X, cell.Y] is null)
                {
                    _cellGrid[cell.X, cell.Y] = cell;
                    _cellCount++;
                    return false;
                }
            }
            return true;
        }

        public void MoveCells(MoveDirection moveDirection)
        {
            int addX = 0;
            int addY = 0;
            if (moveDirection == MoveDirection.LEFT)
            {
                addX = -1;
                for (int x = 1; x < CELL_LENGTH; x++)
                {
                    for (int y = 0; y < CELL_LENGTH; y++)
                    {
                        MoveCell(addX, addY, x, y);
                    }
                }
            }
            else if (moveDirection == MoveDirection.RIGHT)
            {
                addX = 1;
                for (int x = CELL_LENGTH - 2; x >= 0; x--)
                {
                    for (int y = 0; y < CELL_LENGTH; y++)
                    {
                        MoveCell(addX, addY, x, y);
                    }
                }
            }
            else if (moveDirection == MoveDirection.UP)
            {
                addY = -1;
                for (int y = 1; y < CELL_LENGTH; y++)
                {
                    for (int x = 0; x < CELL_LENGTH; x++)
                    {
                        MoveCell(addX, addY, x, y);
                    }
                }
            }
            else if (moveDirection == MoveDirection.DOWN)
            {
                addY = 1;
                for (int y = CELL_LENGTH - 2; y >= 0; y--)
                {
                    for (int x = 0; x < CELL_LENGTH; x++)
                    {
                        MoveCell(addX, addY, x, y);
                    }
                }
            }
        }
    }
}