using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private int _addBonus;

        private int _score = 0;

        public void AddScore()
        {
            _score += _addBonus;
            _scoreText.text = $"{_score}";
        }
    }
}