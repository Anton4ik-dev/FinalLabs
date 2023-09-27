namespace ScoreSystem
{
    public class ScoreController
    {
        private const int ADD_BONUS = 10;

        private int _score = 0;

        public int AddScore()
        {
            return _score += ADD_BONUS;
        }
    }
}