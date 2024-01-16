namespace CellSystem
{
    public class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Value { get; private set; }

        private CellView _cellView;

        public Cell(int x, int y, int value, CellView cellView)
        {
            SetCoordinates(x, y);
            Value = value;
            _cellView = cellView;
        }

        public void SetCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move()
        {
            _cellView.Move(X, Y);
        }

        public void IncreaseValue()
        {
            Value *= 2;
            _cellView.ChangeValue(Value);
        }

        public void Destroy()
        {
            _cellView.gameObject.SetActive(false);
        }
    }
}