using TMPro;
using UnityEngine;
using VContainer;

namespace ScoreSystem
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private ScoreController _scoreController;

        [Inject]
        public void Construct(ScoreController scoreController)
        {
            _scoreController = scoreController;
        }

        public void DrawScore()
        {
            _scoreText.text = $"{_scoreController.AddScore()}";
        }
    }
}